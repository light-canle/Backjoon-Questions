import { Player } from './src/player.js'
import { Creature } from './src/creature.js';

const MAX_LOG = 10; // 로그 창의 최대 줄 수

class UI {
    // 상태창 텍스트 저장용 리스트
    static info = [];


    static addLine(str){
        if (UI.info.length == MAX_LOG)
        {
            UI.info.shift(); // 맨 앞 요소 제거
        }
        UI.info.push(str);
    }

    /**
     * 
     * @param {Player} player 
     */
    static playerSkillUI(player)
    {
        /*
        이런 형태가 되도록 버튼 / 스탯창 추가
        <div id="s1">
            <button id="s1_btn">1</button>
            <div id="s1_info">Power : 00 / Chance : 00</div>
        </div>
        */
        for (let i = 1; i <= player.skillSet.length; i++)
        {
            let skillDiv = document.createElement("div");
            skillDiv.id = `s${i}`;
        
            // 버튼
            let skillButton = document.createElement("button");
            skillButton.id = `s${i}_btn`;
            skillButton.innerText = player.skillSet[i - 1].name;
            skillDiv.appendChild(skillButton);
        
            // 스킬 스탯 설명
            let skillInfo = document.createElement("div");
            skillInfo.id = `s${i}_info`;
            const baseStat = player.skillSet[i-1].baseParameter === parameterType.defense ? "방어력의 " : 
            (player.skillSet[i-1].baseParameter === parameterType.hp ? "최대 HP의 " : "");
            skillInfo.innerText = "위력 : " + baseStat + player.skillSet[i-1].power + "% / 명중 : " + player.skillSet[i-1].chance;
            skillDiv.appendChild(skillInfo);
        
            // skill의 자식이 되도록 추가
            const skillPart = document.getElementById("skill");
            skillPart.appendChild(skillDiv);
        }
        // 버튼 이벤트 추가
        for (let i = 1; i <= player.skillSet.length; i++)
        {
            document.getElementById(`s${i}_btn`).addEventListener('click', useSkill);
        }
    }

    /**
     * 
     * @param {number} level 
     * @param {Player} player 
     * @param {Creature} enemy 
     */
    static updateUI(level, player, enemy)
    {
        // 레벨, 적의 정보
        document.getElementById("level").innerText = `Level ${level}`;
        document.getElementById("enemy_name").innerText = enemy.name;
        document.getElementById("enemy_hp").innerText = (enemy.stat.hp / enemy.stat.maxhp * 100).toFixed(0) + "%";

        // 적 버프 리스트 - 우선 각 버프들을 string 형태로 각 줄마다 출력하도록 했다.
        const enemyBuffPart = document.getElementById("enemy_buff");
        enemyBuffPart.innerText = ""
        
        enemy.buffSet.forEach(function(buff){
            enemyBuffPart.innerText += `${buff.name} : ${buff.type} ${buff.strength} / ${buff.turn}턴\n`;
        });

        // 플레이어 정보
        document.getElementById("player_name").innerText = player.name;
        document.getElementById("player_lv").innerText = "LV : " + player.level;
        document.getElementById("player_hp").innerText = "HP : " + player.stat.hp + "/" + player.stat.maxhp;
        document.getElementById("player_xp").innerText = "XP : " + player.xp + "/" + player.maxXP;

        // 플레이어 버프 리스트 - 우선 각 버프들을 string 형태로 각 줄마다 출력하도록 했다.
        const buffPart = document.getElementById("buff");
        buffPart.innerText = ""
        
        player.buffSet.forEach(function(buff){
            buffPart.innerText += `${buff.name} : ${buff.type} ${buff.strength} / ${buff.turn}턴\n`;
        });

        // 로그창 표시
        document.getElementById("info").innerText = "";
        for (let i = 0; i < UI.info.length; i++)
        {
            document.getElementById("info").innerText += UI.info[i] + "\n";
        }
    }

    // 스킬 버튼 비활성화
    static skillButtonDeactive(player, deactive)
    {
        for (let i = 1; i <= player.skillSet.length; i++) {
            document.getElementById(`s${i}_btn`).disabled = deactive;
        }
    }
}

export {UI}