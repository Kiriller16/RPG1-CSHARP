/*
 * Created by SharpDevelop.
 * User: Кирилл
 * Date: 20.09.2016
 * Time: 23:50
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace FirstConsole
	
{

	public class Hero
	{
		public string name{private set; get;}
		public int hp{set; get;}
		public int damage{private set; get;}
		public int exp{set; get;}
		public int level{private set; get;}
		public int mana{private set; get;}
		public int maxHp{private set; get;}
		public int maxExp{private set; get;}
		public int maxMana{private set; get;}
		public bool isAlive{private set; get;}
		
		public Hero(string name)
		{
			this.name = name;
			hp = 30;
			maxHp = 30;
			mana = 100;
			maxMana = 100;
			damage = 5;
			exp = 0;
			maxExp = 10;
			level = 1;
			isAlive = true;
		}
		
		public bool heal(){
			if(mana >= 10){
				hp+=maxHp/3;
				mana-=10;
				if(hp > maxHp){
					hp = maxHp;
				}
			}
			else{
				return false;
			}
			return true;
		}
		
		public void attac(){
			
		}
		
		public bool levelUp(){
			if(exp >= maxExp){
				exp -= maxExp;
				maxHp += (int) maxHp/2;
				maxMana += (int) maxMana/2;
				maxExp += (int) maxExp/2;
				damage += 5;
				level ++;
				hp = maxHp;
				mana = maxMana;
				return true;
			}
			return false;
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
