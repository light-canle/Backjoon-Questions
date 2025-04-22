import {Stat} from './src/stat.js'
import {Skill} from './src/skill.js'
import { Buff } from './src/buff.js';

class Creature {
    /**
     * 
     * @param {string} name 크리쳐의 이름
     * @param {Stat} stat 크리쳐의 스탯 
     */
    constructor(name, stat) {
        this.name = name;
        this.stat = stat;
        this.skillSet = [];
        this.buffSet = [];
    }

    /**
     * 사용 가능한 스킬을 추가
     * @param {Skill} skill 
     */
    addSkill(skill) {
        this.skillSet.push(skill);
    }

    /**
     * 적용할 버프를 추가 - 복사본으로 추가할 것
     * @param {Buff} buff 
     */
    addBuff(buff) {
        this.buffSet.push(buff);
    }

    /**
     * 턴 종료마다 자신이 가진 버프를 갱신
     */
    applyBuff() {
        // stat의 변화량 초기화
        this.stat.statChangeInit();
        // 버프 적용
        for (let i = 0; i < this.buffSet.length; i++)
        {
            this.buffSet[i].applyBuff(this.stat);
        }
        
        // 턴 수가 양수인 것만 남김
        this.buffSet = this.buffSet.filter((buff => buff.turn > 0));
    }
}

export {Creature}