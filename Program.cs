/*
 * Created by SharpDevelop.
 * User: Кирилл
 * Date: 20.09.2016
 * Time: 23:40
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Threading;

namespace FirstConsole
{
	class Program
	{
		static string[] battleLog;
		static int nowString;
		public static void Main(string[] args)
		{
			battleLog = new string[10];
			nowString = 0;
			Creature enemy = null;
			for(int i = 0; i < 10; i++){
				battleLog[i] = "";
			}
			Console.Write("Привет, путник! Готов ли ты начать свой путь, дабы увеквечить себя в истории?\nНо должен предупредить, путь этот будет не легок, так что? (n/y)\n");
			ConsoleKeyInfo consoleKey;
			consoleKey = Console.ReadKey(true);
			if(consoleKey.Key == ConsoleKey.Y){
				Console.Beep();
				Console.Clear();
				Console.Write("Отлично, так скажи же нам свое имя!\n");
				Hero hero = new Hero(Console.ReadLine());
				Console.Clear();
				Console.Beep();
				Console.Write("Начнем же твое приключение, " + hero.name + "!");
				Thread.Sleep(2000);
				Console.Beep();
				Console.Clear();
				enemy = new Creature(hero);
				battleLog[nowString] = "На вас напал " + enemy.name + "!";
				do{
					Console.WriteLine("Здоровье - " + hero.hp + "/" + hero.maxHp + "\nМана - " + hero.mana +"/" + hero.maxMana + "\nУровень - " + hero.level);
					Console.Write("[");
					for (int i = 0 ; i < (int)((hero.exp * 30)/hero.maxExp);i++){
						Console.Write("*");
					}
					for (int i = (int)((hero.exp * 30)/hero.maxExp) ; i < 30;i++){
						Console.Write("-");
					}
					Console.WriteLine("]\n");
					Console.WriteLine("Здоровье врага - " + enemy.hp + "/" + enemy.maxHp + "\n");
					for(int i = 0; i < 10; i++){
						Console.WriteLine(battleLog[i]);
					}
					consoleKey = Console.ReadKey(true);
					relog();
					switch (consoleKey.Key){
							case ConsoleKey.H:{if(hero.heal()){battleLog[nowString] = "Самолечение";}else{battleLog[nowString] = "Недостаточно маны";} break;}
							case ConsoleKey.A:{battleLog[nowString] = enemy.name + " получил " + hero.damage + " единиц урона"; enemy.hp-=hero.damage;enemy.isDead();break;}
							default:{battleLog[nowString] = "Вы ждете";break;};
					}
					Console.Beep();
					if(enemy.isAlive){
						relog();
						battleLog[nowString] = enemy.name + " нанес вам " + enemy.damage + " единиц урона";
						hero.hp -= enemy.damage;
					}
					enemy.isDead();
					hero.isDead();
					if(!hero.isAlive){
						Console.Clear();
						Console.WriteLine("Game Over");
						break;
					}
				
					if(!enemy.isAlive){
						relog();
						battleLog[nowString] = enemy.name + " повержен";
						hero.exp += 10;
						relog();
						enemy = new Creature(hero);
						battleLog[nowString] = "На вас напал " + enemy.name + "!";
					}
					if(hero.levelUp()){
						relog();
						battleLog[nowString] = "Ваш уровень вырос!";
					}
					Console.Clear();
				}while(consoleKey.Key != ConsoleKey.Escape);
			}
			else{
				Console.Clear();
				Console.Write("Трусливый кабанчег!Пака.");
			}
			Console.ReadKey(true);
		}
		
		public static void relog(){
			if(nowString != 9){
						nowString++;
					}else{
						for(int i = 0; i < 9; i++){
							battleLog[i] = battleLog[i+1];
						}
					}
		}
	}
}