import { atkType } from "./src/skill.js";

class Stat {
    /**
     * 크리쳐 스탯 초기화 (기본 스탯, 계수, 치명타, 저항 등...)
     * @param {number} baseHp 아무런 변경을 거치치 않은 기초 체력
     * @param {number} baseAttack 아무런 변경을 거치치 않은 기초 공격력
     * @param {number} baseDefense 아무런 변경을 거치치 않은 기초 방어력
     */
    constructor(baseHp, baseAttack, baseDefense) {
        // 버프가 다 적용된 뒤 최종 스탯
        /** 버프가 다 적용된 뒤 최종 체력 */
        this.hp = baseHp;
        /** 버프가 다 적용된 뒤 최종 체력 */
        this.maxhp = baseHp;
        /** 버프가 다 적용된 뒤 최종 체력 */
        this.atk = baseAttack;
        /** 버프가 다 적용된 뒤 최종 방어력 */
        this.def = baseDefense;
        /** 체력이 0보다 큰지 여부 */
        this.canBattle = true;

        /** 아무런 변경을 거치치 않은 기초 3스탯 */
        this.base = {
            maxhp: baseHp,
            atk: baseAttack,
            def: baseDefense,
        }

        /** 기초 스탯을 변경하는 곱 계수와 상수 계수. 모든 특성, 효과는 이 수치를 건드림으로서 기초 스탯을 변형해야 한다. */ 
        this.change = {
            atkMul: 1,
            atkAdd: 0,
            defMul: 1,
            defAdd: 0,
            hpMul: 1,
            hpAdd: 0,
        }

        /** 치명타 계열 */
        this.crit = {
            /** 치명타 확률 : 0 ~ 100 */
            critChance : 5,
            /** 치명타 대미지 : 치명타 대미지는 기본 대미지의 (1 + critDmg / 100)배이다. */
            critDmg : 50,
        }
        
        /** (자신이 받은) 속성 공격에 대한 피해 저항 */
        this.resistance = {
          fire : 0,
          ice : 0,
          electro : 0,
        }
        
        /** (자신이 사용한) 속성 공격에 대한 추가 피해량 */
        this.attackBonus = {
          fire : 0,
          ice : 0,
          electro : 0,
        }
    }

    setBaseStat(hp, attack, defense){
        this.base.maxhp = hp;
        this.base.atk = attack;
        this.base.defense = defense;
        return this;
    }

    setCritical(chance, damage){
        this.crit.critChance = chance;
        this.crit.critDmg = damage;
        return this;
    }

    setResistance(type, amount)
    {
        switch (type)
        {
            case atkType.FIRE:
                this.resistance.fire = amount;
                break;
            case atkType.ICE:
                this.resistance.ice = amount;
                break;
            case atkType.ELECTRO:
                this.resistance.electro = amount;
                break;
        }
        return this;
    }

    setAttackBonus(type, amount)
    {
        switch (type)
        {
            case atkType.FIRE:
                this.attackBonus.fire = amount;
                break;
            case atkType.ICE:
                this.attackBonus.ice = amount;
                break;
            case atkType.ELECTRO:
                this.attackBonus.electro = amount;
                break;
        }
        return this;
    }

    /** 가중치를 초기화한다. */
    statChangeInit() {
        this.change.atkMul = 1;
        this.change.atkAdd = 0;
        this.change.defMul = 1;
        this.change.defAdd = 0;
        this.change.hpMul = 1;
        this.change.hpAdd = 0;
    }
    // 
    /** 가중치에 따른 최종 스탯 업데이트.
    공격력 최소는 0, 최대 체력 최소는 1이다. 방어력은 음수가 될 수 있다.
    치명타 확률은 0 ~ 100사이의 범위를 가지고, 치명타 피해의 최소는 0이다. */
    statUpdate() {
        this.atk = this.base.atk * this.change.atkMul + this.change.atkAdd;
        this.atk = Math.max(0, this.atk);

        this.def = this.base.def * this.change.defMul + this.change.defAdd;

        this.maxhp = this.base.maxhp * this.change.hpMul + this.change.hpAdd;
        this.maxhp = Math.max(1, this.maxhp);
    }
    Attack() {
        this.statUpdate();
        return this.atk;
    }
    Defense() {
        this.statUpdate();
        return this.def;
    }
    Hp() {
        this.statUpdate();
        return this.hp;
    }
    Heal(amount) {
        this.statUpdate();
        this.hp = Math.min(this.hp + amount, this.maxhp);
    }
    /**
     * 저항 및 방어력을 적용받는 피해를 입힌다.
     * @param {number} amount 공격측 대미지
     * @param {atkType} type 공격측 기술의 속성
     * @returns 최종 대미지 반환 (메시지 출력용)
     */
    Damage(amount, type) 
    {
        this.statUpdate();
        // 방어력 우선 적용
        let finalDamage = amount - this.def;
        // 계산된 대미지에 내성 적용
        finalDamage *= Math.max(1.0 - (this.Resistance(type) / 100.0), 0.0);
        finalDamage = Math.floor(Math.max(0, finalDamage));
        // 대미지만큼 체력 차감
        this.hp = Math.max(this.hp - finalDamage, 0);
        this.canBattle = this.hp > 0;
        // 출력을 위한 최종 대미지 반환
        return finalDamage;
    }

    /**
     * 
     * @param {atkType} type 기술의 타입
     * @returns 입력한 타입의 대응하는 저항력을 반환
     */
    Resistance(type)
    {
        switch (type)
        {
            case atkType.FIRE:
                return this.resistance.fire;
            case atkType.ICE:
                return this.resistance.ice;
            case atkType.ELECTRO:
                return this.resistance.electro;
            default:
                return 0;
        }
    }

    /**
     * 
     * @param {atkType} type 기술의 타입
     * @returns 입력한 타입의 대응하는 추가 피해량을 반환
     */
    AttackBonus(type)
    {
        switch (type)
        {
            case atkType.FIRE:
                return this.attackBonus.fire;
            case atkType.ICE:
                return this.attackBonus.ice;
            case atkType.ELECTRO:
                return this.attackBonus.electro;
            default:
                return 0;
        }
    }

    /**
     * 방어력을 무시하고 amount만큼 체력을 줄인다.
     * @param {number} amount 입힐 피해량
     */
    ConstantDamage(amount)
    {
        this.statUpdate();
        
        this.hp = Math.max(this.hp - amount, 0);
        this.canBattle = this.hp > 0;
    }
    CanBattle() {
        return this.canBattle;
    }
}

export {Stat}