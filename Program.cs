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

            int hitPointsBoss = 60;

            int maxHitPointsPlayer = 10;
            int hitPointsPlayer = maxHitPointsPlayer;

            int maxManaPlayer = 10;
            int manaPlayer = maxManaPlayer;

            int damagePlayer = 10;

            int damageFireBall = 20;
            int manaFireBall = 3;

            int damageExplosion = 30;

            int heal = 5;
            int pointsHeal = 3;

            string newTurn = null;
            string helpMenu = "Нажмите 1, чтобы атаковать.\n" +
                "Нажмите 2, чтобы запустить огненный шар\n" +
                "Нажмите 3, чтобы использовать взрыв\n" +
                "Нажмите 4, чтобы выпить зелье лечение.";

            bool endGame = false;

            Console.WriteLine("Последнее задание после которого вы завершите карьеру и отправитесь на покой.\n" +
                "У вас плохое предчуствие, рефлексы уже не те, вы можете ошибиться и она станет роковой.\n" +
                "Вы входите в пещеру тролля.\n" +
                "Он вас ждал...");

            while (endGame == false)
            {
                int damageBoss = random.Next(lowLimitRandom, highLimitRandom + 1);
                Console.WriteLine($"Тролль наносит вам {damageBoss} урона\n" +
                    "У вас осталось: " + (hitPointsPlayer -= damageBoss) + " HP");

                if (hitPointsPlayer > 0)
                {
                    Console.WriteLine("Вы ещё стоите на ногах.\n" +
                        $"У вас осталось: {hitPointsPlayer} HP");

                    string lastTurn = newTurn;

                    Console.WriteLine("Ваш ход:\n" +
                        helpMenu);
                    newTurn = Console.ReadLine();

                    switch (newTurn)
                    {
                        case ButtonAttack:
                            hitPointsBoss -= damagePlayer;

                            Console.WriteLine("Одним взмахом меча вы наносите ему порез.\n" +
                                $"Его шкура слишком толстая. Подобный удар разруил бы другого пополам.\n" +
                                $"Без магии тут не обойтись.\n" +
                                $"У тролля {hitPointsBoss} HP.");
                            break;

                        case ButtonFireBall:

                            if (manaPlayer - manaFireBall > manaFireBall)
                            {
                                manaPlayer -= manaFireBall;
                                hitPointsBoss -= damageFireBall;

                                Console.WriteLine("Вы вытягиваете левую руку вперед и на кончиках ваших пальцев появляется огненный шар.\n" +
                                "Он летит в тролля и обжигает его тело.\n" +
                                "Благодаря этому открылся магический канал и можно использовать умение взрыв.\n" +
                                $"Тролль вопит. У тролля {hitPointsBoss} HP.\n" +
                                $"Вы чувствуете себя уставшим. Теперь у вас {manaPlayer} маны.");
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

                            if (lastTurn == ButtonFireBall)
                            {
                                hitPointsBoss -= damageExplosion;
                                Console.WriteLine("Вы щелкаете пальцами. По магическому каналу от вас проскакивет молния.\n" +
                                    "Рядом с троллем происходит взрыв.\n" +
                                    "Вы слышите истошный вопль.\n" +
                                    "Похоже, он ещё больше разозлился.\n" +
                                    $"У тролля {hitPointsBoss} HP.");
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

                            if (pointsHeal > 0)
                            {
                                hitPointsPlayer += heal;

                                if (hitPointsPlayer > maxHitPointsPlayer)
                                {
                                    hitPointsPlayer = maxHitPointsPlayer;
                                }

                                manaPlayer += heal;

                                if (manaPlayer > maxManaPlayer)
                                {
                                    manaPlayer = maxManaPlayer;
                                }

                                pointsHeal--;
                                Console.WriteLine($"Вы достаёте зелье лечения из поясной сумки и ловким, отточенным движением выпиваете его залпом.\n" +
                                    $"По вашему горлу растекается теплый, неприятный на вкус травянистый напиток.\n" +
                                    $"У вас осталось {pointsHeal} флакона.\n" +
                                    $"Теперь у вас {hitPointsPlayer} HP и {manaPlayer} маны.");
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
                else if (hitPointsPlayer <= 0)
                {
                    endGame = true;
                    Console.WriteLine("Это был сильный удар.\n" +
                        "Вы лежите на земле.\n" +
                        "Похоже, это конец.\n" +
                        "Последнее что вы видете:\n" +
                        "Тролль замахивается и огромная дубина летит вам прямо в лицо.\n" +
                        $"У вас осталось {hitPointsPlayer} HP, у тролля {hitPointsBoss}.");
                    break;
                }
                
                if (hitPointsBoss <= 0)
                {
                    endGame = true;
                    Console.WriteLine("Тролль леижит поверженный у ваших ног.\n" +
                        "Вы отрубаете ему голову и уходите.\n" +
                        "Последнее дело завершено.\n" +
                        $"У вас осталось {hitPointsPlayer} HP, у тролля {hitPointsBoss}.");
                }
            }

            Console.WriteLine("Это конец");
        }
    }
}
