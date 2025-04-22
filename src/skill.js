import { Stat } from './src/stat.js'
import { Buff } from './src/buff.js'

/** SKill의 대미지의 기반이 되는 기초 스탯 */
const parameterType =
{
    attack : 'attack',
    defense : 'defense',
    hp : 'hp',
}

/** 스킬 공격의 속성 - other은 특수한 속성으로 스탯의 추가 대미지나 내성을 적용 받지 않는다는 특징이 있다. */
const atkType = {
    NORMAL: "normal",
    FIRE: "fire",
    ICE: "ice",
    ELECTRO: "electro",
    WATER: "water",
    WIND: "wind",
    ENERGY: "energy",
    OTHER: "other"
}

Object.freeze(parameterType);
Object.freeze(atkType);

class Skill {
    /**
     * 
     * @param {string} name 기술의 이름
     * @param {number} power 기술의 위력 
     * @param {number} chance 기술의 명중률
     */
    constructor (name, power, chance)
    {
        /** @type {string} 기술의 이름 */
        this.name = name;
        /** @type {number} 기술의 위력, 100인 경우 기본 스탯값이 기준 대미지가 된다. */
        this.power = power;
        /** @type {number} 기술의 명중률, 100인 경우 기본적으로 항상 명중 */
        this.chance = chance;

        // 추가로 필요한 수치들
        /** @type {atkType} 기술의 속성, 기본적으로는 물리(Normal)이다. */
        this.type = atkType.NORMAL;
        /** @type {parameterType} 기술의 대미지를 결정하는 기본 스탯으로, 기본적으로는 공격력(parameterType.attack)을 기반으로 한다. */
        this.baseParameter = parameterType.attack;
        /** @type {number} 기술을 썼을 때 추가로 입힐 상수 대미지 - 치명타 적용을 받지 않는다. */
        this.addidionalDamage = 0;
        /** @type {Buff} 기술이 명중했을 시 부여되는 효과 */
        this.buff = null;

        // 자신을 반환해서 체인 메소드로 다양한 추가 속성들을 추가하도록 한다.
        return this;
    }

    /**
     * 공격 속성을 바꾼다.
     * @param {atkType} 바꿀 속성으로 atkType안의 변수 중 하나
     * @returns 자신을 반환
     */
    setType(type)
    {
        this.type = type;
        return this;
    }

    /**
     * 기반 스탯을 바꾼다.
     * @param {baseParameter} 바꿀 스탯으로 parameterType안의 변수 중 하나
     * @returns 자신을 반환
     */
    setParameterType(baseParameter)
    {
        this.baseParameter = baseParameter;
        return this;
    }

    /**
     * 상수 대미지를 바꾼다.
     * @param {number} 대미지 값
     * @returns 자신을 반환
     */
    setAddidionalDamage(addidionalDamage)
    {
        this.addidionalDamage = addidionalDamage;
        return this;
    }

    /**
     * 버프를 추가한다.
     * new Buff()로 추가하는 것을 권장
     * @param {Buff} buff 적용할 버프
     * @returns 자신을 반환
     */
    setBuff(buff)
    {
        this.buff = buff;
        return this;
    }
    
    /**
     * 이 스킬의 시전 결과를 반환.
     * @param {Stat} stat 이 스킬을 사용한 크리쳐의 스탯 
     * @returns 스킬의 결과를 SkillResult 형태로 반환
     */
    Result(stat) {
        // 빗나감 여부
        if (this.chance / 100 < Math.random())
        {
            return new SkillResult(0, this.type, false, false, null);
        }
        // 기본 파리미터에 따른 기본 대미지 구하기
        let attackerDmg = 0;
        switch (this.baseParameter)
        {
            case parameterType.attack:
                attackerDmg = stat.Attack();
                break;
            case parameterType.defense:
                attackerDmg = stat.Defense();
                break;
            case parameterType.hp:
                attackerDmg = stat.Hp();
                break;
        }

        // 속성이 부여된 경우 그에 대응하는 추가 피해 보너스 가져오기 
        attackerDmg *= (1.0 + stat.AttackBonus(this.type) / 100.0);
        // 크리티컬 히트 여부를 확인
        let critMultiplier = 1.0;
        let isCrit = false;
        if (stat.crit.critChance > Math.random() * 100.0)
        {
            critMultiplier += stat.crit.critDmg / 100.0;
            isCrit = true;
        }
        // 입력되는 대미지 수치에 기술의 위력, 크리티컬 계수를 곱하고 추가 상수 대미지를 더한 뒤 0.9 ~ 1.1의 가중치를 준 값을 반환
        let atk = attackerDmg * (this.power / 100.0) * critMultiplier + this.addidionalDamage;
        atk *= Random.rand_float(0.9, 1.1);
        atk = Math.floor(atk);
        // 버프는 복사본을 반환한다.
        if (this.buff !== null)
        {
            return new SkillResult(atk, this.type, true, isCrit, this.buff.copy());
        }
        else
        {
            return new SkillResult(atk, this.type, true, isCrit, null);
        }
    }
}

class SkillResult
{
    /**
     * 기술의 결과 상태를 담는 구조체.
     * 이 클래스의 "반환"은 SKill내에서만 이루어지고, 그 외에서는 만들어진 SKillResult를 참조만 한다.
     * @param {number} dmg 공격측 대미지 - 방어측의 방어력이나 내성에 의해 조정되기 전 값
     * @param {atkType} type 공격측 기술의 타입
     * @param {boolean} hit 공격 명중 여부
     * @param {boolean} crit 치명타 여부
     * @param {Buff} buff 적용되는 버프
     */
    constructor (dmg, type, hit, crit, buff)
    {
        this.damage = dmg;
        this.type = type;
        this.ishit = hit;
        this.iscrit = crit;
        this.buff = buff;
    }
}

export {Skill, SkillResult, parameterType, atkType}