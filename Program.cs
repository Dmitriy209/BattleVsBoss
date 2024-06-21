using System;

namespace BattleVsBoss
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string ButtonAttack = "1";
            const string ButtonFireBall = "2";
            const string ButtonExplosion = "3";
            const string ButtonHeal = "4";

            Random random = new Random();
            int lowLimitRandom = 1;
            int highLimitRandom = 5;

            int bossHitPoints = 60;

            int playerMaxHitPoints = 10;
            int playerHitPoints = playerMaxHitPoints;

            int playerMaxMana = 10;
            int playerMana = playerMaxMana;

            int playerDamage = 10;

            int fireBallDamage = 20;
            int fireBallMana = 3;

            int explosionDamage = 30;

            int heal = 5;
            int healPoints = 3;

            string newTurn = null;
            string helpMenu = $"Нажмите {ButtonAttack}, чтобы атаковать.\n" +
                $"Нажмите {ButtonFireBall}, чтобы запустить огненный шар\n" +
                $"Нажмите {ButtonExplosion}, чтобы использовать взрыв\n" +
                $"Нажмите {ButtonHeal}, чтобы выпить зелье лечение.";

            Console.WriteLine("Последнее задание после которого вы завершите карьеру и отправитесь на покой.\n" +
                "У вас плохое предчуствие, рефлексы уже не те, вы можете ошибиться и она станет роковой.\n" +
                "Вы входите в пещеру тролля.\n" +
                "Он вас ждал...");

            bool isLastTurnFireBall = false;

            while (playerHitPoints <= 0 || bossHitPoints <= 0 == false)
            {
                int damageBoss = random.Next(lowLimitRandom, highLimitRandom + 1);
                int playerInputDamage = playerHitPoints -= damageBoss;

                Console.WriteLine($"Тролль наносит вам {damageBoss} урона\n" +
                    $"У вас осталось: {playerInputDamage} HP");

                if (playerHitPoints > 0)
                {
                    Console.WriteLine("Вы ещё стоите на ногах.\n" +
                        $"У вас осталось: {playerHitPoints} HP");

                    if (newTurn == ButtonFireBall)
                    {
                        isLastTurnFireBall = true;
                    }

                    Console.WriteLine($"Ваш ход:\n{helpMenu}");
                    newTurn = Console.ReadLine();

                    switch (newTurn)
                    {
                        case ButtonAttack:
                            bossHitPoints -= playerDamage;

                            Console.WriteLine("Одним взмахом меча вы наносите ему порез.\n" +
                                $"Его шкура слишком толстая. Подобный удар разруил бы другого пополам.\n" +
                                $"Без магии тут не обойтись.\n" +
                                $"У тролля {bossHitPoints} HP.");
                            break;

                        case ButtonFireBall:
                            if (playerMana >= fireBallMana)
                            {
                                playerMana -= fireBallMana;
                                bossHitPoints -= fireBallDamage;

                                Console.WriteLine("Вы вытягиваете левую руку вперед и на кончиках ваших пальцев появляется огненный шар.\n" +
                                "Он летит в тролля и обжигает его тело.\n" +
                                "Благодаря этому открылся магический канал и можно использовать умение взрыв.\n" +
                                $"Тролль вопит. У тролля {bossHitPoints} HP.\n" +
                                $"Вы чувствуете себя уставшим. Теперь у вас {playerMana} маны.");
                            }
                            else
                            {
                                Console.WriteLine("Вы вытягиваете левую руку вперед...\n" +
                                    "Но вместо огромного огненного шара видно лишь слабое свечение.\n" +
                                    "У вас не осталось сил и вы потеряли драгоценное время.\n" +
                                    "Вы пропускаете ход.");
                            }
                            break;

                        case ButtonExplosion:

                            if (isLastTurnFireBall)
                            {
                                isLastTurnFireBall = false;
                                bossHitPoints -= explosionDamage;
                                Console.WriteLine("Вы щелкаете пальцами. По магическому каналу от вас проскакивет молния.\n" +
                                    "Рядом с троллем происходит взрыв.\n" +
                                    "Вы слышите истошный вопль.\n" +
                                    "Похоже, он ещё больше разозлился.\n" +
                                    $"У тролля {bossHitPoints} HP.");
                            }
                            else
                            {
                                Console.WriteLine("Вы щелкаете пальцами. Ничего не происходит. Магический канал закрыт.\n" +
                                    "Похоже, вы стали слишком стары и не помните даже того, что было буквально одно мгновение назад.\n" +
                                    "Возможно, это ваш последний бой...\n" +
                                    "Вы пропускаете ход.");
                            }
                            break;

                        case ButtonHeal:
                            if (healPoints > 0)
                            {
                                playerHitPoints += heal;

                                if (playerHitPoints > playerMaxHitPoints)
                                {
                                    playerHitPoints = playerMaxHitPoints;
                                }

                                playerMana += heal;

                                if (playerMana > playerMaxMana)
                                {
                                    playerMana = playerMaxMana;
                                }

                                healPoints--;
                                Console.WriteLine($"Вы достаёте зелье лечения из поясной сумки и ловким, отточенным движением выпиваете его залпом.\n" +
                                    $"По вашему горлу растекается теплый, неприятный на вкус травянистый напиток.\n" +
                                    $"У вас осталось {healPoints} флакона.\n" +
                                    $"Теперь у вас {playerHitPoints} HP и {playerMana} маны.");
                            }
                            else
                            {
                                Console.WriteLine("Вы тянетесь за очередным зельем лечения, но ничего не находите.\n" +
                                    "Похоже, вы стали слишком стары и забыли сколько у вас осталось в запасе.\n" +
                                    "Возможно, это ваш последний бой...\n" +
                                    "Вы пропускаете ход.");
                            }
                            break;

                        default:
                            Console.WriteLine("Вы оценивающе смотрите на тролля.\n" +
                                "Он огромный, сильный и ... очень вонючий...\n" +
                                "Вы замешкались и пропускаете ход.");
                            break;
                    }
                }
            }

            if (playerHitPoints <= 0 && bossHitPoints > 0)
            {
                Console.WriteLine("Это был сильный удар.\n" +
                    "Вы лежите на земле.\n" +
                    "Похоже, это конец.\n" +
                    "Последнее что вы видете:\n" +
                    "Тролль замахивается и огромная дубина летит вам прямо в лицо.\n" +
                    $"У вас осталось {playerHitPoints} HP, у тролля {bossHitPoints}.");
            }
            else if (bossHitPoints <= 0 && playerHitPoints > 0)
            {
                Console.WriteLine("Тролль леижит поверженный у ваших ног.\n" +
                    "Вы отрубаете ему голову и уходите.\n" +
                    "Последнее дело завершено.\n" +
                    $"У вас осталось {playerHitPoints} HP, у тролля {bossHitPoints}.");
            }
            else
            {
                Console.WriteLine("Это был ваш последний бой\n" +
                    "Вы оба лежите на земле и истекаете кровью.\n" +
                    "Ваше дыхание постепенно замедляется и вы умираете.");
            }

            Console.WriteLine("Это конец");
        }
    }
}
