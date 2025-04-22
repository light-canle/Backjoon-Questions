import { Random } from './src/util.js'
import { Player } from './src/player.js'
import { Creature } from './src/creature.js';
import { parameterType, Skill } from './src/skill.js';
import { Stat } from './src/stat.js';

const n = prompt("당신의 이름을 입력하세요.");
let player = new Player(n, new Stat(200, 60, 0));
let enemy;

let level = 0;
newLevel();

player.addSkill(new Skill("일반공격", 50, 100));
player.addSkill(new Skill("강공격", 70, 72));
player.addSkill(new Skill("기습", 90, 56));
player.addSkill(new Skill("필살기", 110, 45));
player.addSkill(new Skill("공격력 감소", 0, 90)
                    .setBuff(new Buff("공격력 감소", buffType.ATTACK_PERCENT_DOWN, 33, 2)) );
player.addSkill(new Skill("힘껏 치기", 120, 100)
                    .setParameterType(parameterType.defense));

UI.addLine(`${player.name}의 여정이 시작된다.`);
UI.updateUI(level, player, enemy);
UI.playerSkillUI(player);

let havingBattle = true;

function useSkill(e) {
    if (!havingBattle) {
        return;
    }

    // 플레이어 턴
    // 버프 적용
    player.applyBuff();
    

    // 누른 버튼을 가져온 뒤 스킬 번호를 알아낸다.
    const skillID = e.target.id;
    const p = skillID.indexOf("_");
    const skillNum = Number(skillID.substring(1, p)) - 1; // 스킬 번호를 가져옴 -> sXX_btn에서 XX만 가져옴

    // 그 스킬의 정보를 가져와 몬스터를 공격
    if (player.stat.CanBattle()) {
        let atkResult = player.skillSet[skillNum].Result(player.stat);
        let finalDamage = enemy.stat.Damage(atkResult.damage, atkResult.type);
        if (atkResult.buff !== null)
        {
            enemy.addBuff(atkResult.buff);
        }

        UI.addLine(`${player.name}의 ${player.skillSet[skillNum].name}!`);
        // 명중 여부에 따른 메시지 출력
        if (atkResult.ishit)
        {
            if (atkResult.iscrit)
            {
                UI.addLine(`치명타 적중!`);
            }
            if (finalDamage > 0)
            {
                UI.addLine(`${player.name}(이)가 ${enemy.name}에게 ${finalDamage}의 피해를 주었다!`);
            }
            if (atkResult.buff !== null)
            {
                UI.addLine(`${enemy.name}은(는) ${atkResult.buff.name}효과를 ${atkResult.buff.turn}턴 받았다!`);
            }
            if (atkResult.buff == null && finalDamage == 0)
            {
                UI.addLine(`그러나 ${enemy.name}에게 피해는 없었다!`);
            }
        }
        else
        {
            UI.addLine(`하지만 ${player.name}의 공격은 빗나갔다!`);
        }
        

        // 몬스터가 쓰러졌는지 판단
        if (!enemy.stat.CanBattle()) {
            UI.addLine(`${player.name}이(가) ${enemy.name}을(를) 쓰러뜨렸다!`);
            winPrize();
            newLevel();
            UI.updateUI(level, player, enemy);
            return;
        }
    }

    // 몬스터 턴
    // 몬스터 버프 적용
    enemy.applyBuff();

    // 몬스터가 플레이어를 공격
    if (enemy.stat.CanBattle()) {
        let toUseSkill = Random.choice(enemy.skillSet);
        let atkResult = toUseSkill.Result(enemy.stat);

        let finalDamage = player.stat.Damage(atkResult.damage, atkResult.type);
        if (atkResult.buff !== null)
        {
            player.addBuff(atkResult.buff);
        }

        UI.addLine(`${enemy.name}의 ${toUseSkill.name}!`);
        // 명중 여부에 따른 메시지 출력
        if (atkResult.ishit)
        {
            if (atkResult.iscrit)
            {
                UI.addLine(`치명타 적중!`);
            }
            if (finalDamage > 0)
            {
                UI.addLine(`${enemy.name}(이)가 ${player.name}에게 ${finalDamage}의 피해를 주었다!`);
            }
            if (atkResult.buff !== null)
            {
                UI.addLine(`${player.name}은(는) ${atkResult.buff.name}효과를 ${atkResult.buff.turn}턴 받았다!`);
            }
            if (atkResult.buff == null && finalDamage == 0)
            {
                UI.addLine(`그러나 ${player.name}에게 피해는 없었다!`);
            }
        }
        else
        {
            UI.addLine(`하지만 ${enemy.name}의 공격은 빗나갔다!`);
        }

        // 플레이어가 쓰러졌는지 판단
        if (!player.stat.CanBattle()) {
            UI.addLine(`${player.name}이(가) ${enemy.name}에게 당했다... ${player.name}의 여정이 끝났다.`);
            havingBattle = false;
            UI.skillButtonDeactive(player, true);
        }
    }

    // UI 업데이트
    UI.updateUI(level, player, enemy);
}

function winPrize() {
    // 승리한 뒤 보상
    let xp = Math.floor(level * 6 * Random.rand_float(0.7, 1.3) + 0.08 * level * level);
    UI.addLine(`${player.name}은(는) ${xp}의 경험치를 얻었다.`);
    player.gainXP(xp);
    // hp 회복
    if (level % 5 == 0) {
        player.stat.hp = player.stat.maxhp;
        player.addBuff(new Buff("공격력 증가", buffType.ATTACK_PERCENT_UP, 50, 3));
    }
    else {
        player.stat.hp = Math.min(player.stat.maxhp, Math.floor(player.stat.hp + player.stat.maxhp * Random.rand_float(0.1, 0.25)));
    }
}


function newLevel() {
    // 새로운 적을 스폰
    level += 1;
    let hp = Math.floor((90 + (level * 8)) * Random.rand_float(0.9, 1.1));
    let atk = Math.floor((8 + level * 2.2) * Random.rand_float(0.9, 1.1));
    let def = Math.floor((1 + level * 0.4) * Random.rand_float(0.9, 1.1));
    enemy = new Creature(`mon${level}`, new Stat(hp, atk, def));
    enemy.addSkill(new Skill("일반공격", 55, 90));
    if (level % 5 == 0)
    {
        enemy.addSkill(new Skill("강공격", 100, 80));
    }
    if (level > 15)
    {
        enemy.addSkill(new Skill("기습", 75, 75));
        enemy.addSkill(new Skill("갑옷 약화", 0, 60)
                        .setBuff(new Buff("방어력 감소", buffType.DEFENSE_PERCENT_DOWN, 25, 2)));
    }
}
