import {Stat} from './src/stat.js'

/** 적용되는 버프의 종류를 담은 열거형 */
const buffType = {
    ATTACK_PERCENT_UP: "attack_percent_up",
    ATTACK_PERCENT_DOWN: "attack_percent_down",
    DEFENSE_PERCENT_UP: "defense_percent_up",
    DEFENSE_PERCENT_DOWN: "defense_percent_down",
    MAXHP_PERCENT_UP: "maxhp_percent_up",
    MAXHP_PERCENT_DOWN: "maxhp_percent_down",
    HP_PERCENT_RESTORE: "hp_percent_restore",
    HP_PERCENT_DAMAGE: "hp_percent_damage",
}

Object.freeze(buffType);

class Buff {
    /**
     *  
     * @param {string} name 버프의 이름
     * @param {buffType} type 버프의 종류로 buffType에 있는 변수 중 하나
     * @param {number} strength 특정 버프의 강도
     * @param {number} turn 버프의 지속 시간
     */
    constructor(name, type, strength, turn) {
        this.name = name;
        this.type = type;
        this.strength = strength;
        this.turn = turn;
    }

    /**
     * 
     * @returns 해당 효과의 깊은 복사본을 반환
     */
    copy()
    {
        let name = this.name;
        let type = this.type;
        let strength = this.strength;
        let turn = this.turn;

        return new Buff(name, type, strength, turn);
    }

    /**
     * 크리쳐에게 효과 적용
     * @param {Stat} stat 적용받을 크리쳐의 stat이다.
     */ 
    applyBuff(stat) {
        this.turn = this.turn - 1;
        this.applyByType(stat);
    }

    /**
     * 각 종류에 따른 효과를 구현
     * applyBuff() 함수를 통해 호출되어야 한다.
     * XX_PERCENT_UP/DOWN은 XX에 해당하는 스탯을 strength%만큼 올리거나 내린다.
     * @param {Stat} stat 적용받을 크리쳐의 stat이다.
     */
    applyByType(stat) {
        switch (this.type) {
            case buffType.ATTACK_PERCENT_UP:
                stat.change.atkMul += this.strength / 100.0;
                break;
            case buffType.ATTACK_PERCENT_DOWN:
                stat.change.atkMul -= this.strength / 100.0;
                stat.change.atkMul = Math.max(stat.change.atkMul, 0);
                break;
            case buffType.DEFENSE_PERCENT_UP:
                stat.change.defMul += this.strength / 100.0;
                break;
            case buffType.DEFENSE_PERCENT_DOWN:
                stat.change.defMul -= this.strength / 100.0;
                stat.change.defMul = Math.max(stat.change.defMul, 0);
                break;
            case buffType.MAXHP_PERCENT_UP:
                stat.change.hpMul += this.strength / 100.0;
                break;
            case buffType.MAXHP_PERCENT_DOWN:
                stat.change.hpMul -= this.strength / 100.0;
                stat.change.hpMul = Math.max(stat.change.hpMul, 0);
                break;
        }
    }
}

export {buffType, Buff}