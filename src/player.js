import { Stat } from './src/stat.js'
import { Creature } from './src/creature.js';

class Player extends Creature
{
    /**
     * 
     * @param {string} name 플레이어 이름
     * @param {Stat} stat 플레이어의 초기 스탯
     */
    constructor(name, stat)
    {
        super(name, stat);
        this.xp = 0;
        this.maxXP = 14;
        this.level = 1;
    }

    /**
     * 경험치를 부여하고 최대 경험치량 이상이 되면 레벨을 올리고 스탯을 올린다. (추후 스탯 올리는 부분은 이동)
     * @param {number} amount 얻은 경험치의 양
     */
    gainXP(amount)
    {
        this.xp += amount;
        while (this.xp >= this.maxXP)
        {
            this.xp -= this.maxXP;
            this.level += 1;
            this.maxXP = Math.floor(10 + this.level * 4 + (this.level * this.level) * 0.15);

            // 스탯 업그레이드
            this.stat.base.maxhp += 3;
            this.stat.base.atk += 2;
            this.stat.base.def += 1;
        }
    }
}

export {Player}