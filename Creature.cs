/*
 * Created by SharpDevelop.
 * User: Кирилл
 * Date: 25.09.2016
 * Time: 14:32
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace FirstConsole
{
	public class Creature
	{
		public string name{private set; get;}
		public int hp{set; get;}
		public int maxHp{private set; get;}
		public int damage{private set; get;}
		public bool isAlive{private set; get;}
		public Hero hero;
		Random r;
		public Creature(Hero hero)
		{
			this.hero = hero;
			r = new Random(System.DateTime.Now.Second);
			switch(r.Next(1,5)){
				case 1:{name = "Орк"; break;}
				case 2:{name = "Слизень"; break;}
				case 3:{name = "Птеродактель"; break;}
				case 4:{name = "Мурлок"; break;}
			}
			damage = r.Next(hero.damage,(int)hero.damage + hero.damage/2);
			maxHp = r.Next(hero.hp,(int)hero.maxHp + hero.maxHp/2);
			hp = maxHp;
			isAlive = true;
		}
		
		public void dead(){
			isAlive = false;
		}
		public void isDead(){
			if(!(hp > 0)){
				hp = 0;
				dead();
			}
		}
	}
}
