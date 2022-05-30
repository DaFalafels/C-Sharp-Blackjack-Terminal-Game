using System;
using System.Threading;
using System.Text;
using System.IO;

namespace name
{
	public class Name
	{
		public static void delay()
		{
			
			Thread.Sleep(1000);

		}

        public static void AceEqualsWhat(ref int ace)
        {

            do
            {

                Console.Write("\nWhat do you want your Ace to be? (1/11) "); 
            randomInput:
                string randomInput = Console.ReadLine();
                int numCheck;

                if (int.TryParse(randomInput, out numCheck)) 
                {

                    ace = Convert.ToInt32(randomInput);

                }

                else 
                {

                    Console.WriteLine("\nInvalid entry. Please enter a valid number: (1/11) ");
                    goto randomInput;

                }

                if ((ace != 1) && (ace != 11))
                {

                    Console.Write("Invalid value. Please enter an amount you can use for an Ace: (1 or 11) ");
                    goto randomInput;

                }

            } while ((ace != 1) && (ace != 11));

        }

        public static void ToSeekRecords() 
        {

            Console.Write("\nDo you want to know how it happened? (y/n) ");
            string HowItHappened = Console.ReadLine();

            while ((!HowItHappened.Equals("Y")) && (!HowItHappened.Equals("y")) && (!HowItHappened.Equals("N")) && (!HowItHappened.Equals("n"))) 
            {

                Console.Write("\nInvalid entry. Please enter a valid entry: (y/n) ");
                HowItHappened = Console.ReadLine();

            }

            if ((HowItHappened.Equals("Y")) || (HowItHappened.Equals("y")))
            {

                SeekingRecords(); //this would call the method 'SeekingRecords', in which the user will be able to review the game

            }

        }

        public static void SeekingRecords() //this method is used to open and read the Records.txt file
        {
            string line;
            line = File.ReadAllText(@"Records.txt"); //this is used to read all the text in the Records.txt file, and copy it to the variable 'line'
            Console.WriteLine(line);
        }

		public static void Main(string[] args)
		{

            StreamReader reader = new StreamReader(@"Instructions.txt"); //this would declare 'reader', and will be used to write text into the Instructions.txt file

            string name; //the first variable 'name' of data type string
			string knowHowToPlay; //the second variable 'knowHowToPlay' of data type string
            string instructions; //the third variable 'instructions' for getting instructions from a text file
            int amountOfNumber = 13; //for fourth variable 'amountOfNumber' for knowing the number of every line in the Instructions.txt file
            string readyToPlay; //the fifth variable 'readyToPlay' of data type string
			double stars = 10; //the sixth variable 'stars' of data type double
			double bet = 0; //the seventh variable 'bet' of data type double
			int dealerCardNo1; //the eighth variable 'dealerCardNo1' of data type int
			int dealerCardNo2; //the ninth variable 'dealerCardNo2' of data type int
			int dealerTotalValue; //the tenth variable 'dealerTotalValue' of data type int
			int playerCardNo1; //the eleventh variable 'playerCardNo1' of data type int
			int playerCardNo2; //the twelfth variable 'playerCardNo2' of data type int
			int aceEqualsWhat; //the thirteenth variable 'aceEqualsWhat' of data type int
			int playerTotalValue; //the fourteenth variable 'playerTotalValue' of data type int
			string surrender = null; //the fifteenth variable 'surrender' of data type string
			string split = null; //the sixteenth variable 'split' of data type string
			int playerOtherTotalValue; //the seventeenth variable 'playerOtherTotalValue' of data type int
			string insurance; //the eighteenth variable 'insurance' of data type string
			double insuranceBet = bet * 0.5; //the ninteenth variable 'insuranceBet' of data type double
			string doubleDown = null; //the twentieth variable 'doubleDown' of data type string
			string hitOrStand = null; //the twenty first variable 'hitOrStand' of data type string
			int nextPlayerCard; //the twenty second variable 'nextPlayerCard' of data type int
			int nextDealerCard; //the twenty third variable 'nextDealerCard' of data type int
			string playAgain; //the twenty fourth variable 'playAgain' of data type string

            Console.WriteLine("    WELCOME TO BLACKJACK!");
            Console.WriteLine("-----------------------------");

            Console.Write("What is your name? "); 
			name = Console.ReadLine();

			Console.WriteLine("Welcome to the game of Blackjack " + name + "!"); 

			Console.Write("\nDo you know how to play the game? (y/n) "); 
			knowHowToPlay = Console.ReadLine();

			while ((!knowHowToPlay.Equals("Y")) && (!knowHowToPlay.Equals("y")) && (!knowHowToPlay.Equals("N")) && (!knowHowToPlay.Equals("n"))) 
			{

				Console.Write("\nInvalid entry. Please enter a valid entry: (y/n) ");
				knowHowToPlay = Console.ReadLine();

			}

			if ((knowHowToPlay.Equals("N")) || (knowHowToPlay.Equals("n"))) 
			{

                for (int i = 1; i <= amountOfNumber; i++) //this is used to read all the text in the Records.txt file, and copy it to the variable 'instructions' (line by line)
                {

                    instructions = reader.ReadLine();
                    Console.WriteLine(instructions);

                    if ((i == 6) || (i == 13))
                    {

                        delay();

                    }

                }

                reader.Close(); //this is used to close the Instructions.txt file

                Console.Write("\nAre you ready to play? (y) "); 
				readyToPlay = Console.ReadLine();

				while ((!readyToPlay.Equals("Y")) && (!readyToPlay.Equals("y"))) 
				{

					Console.Write("\nInvalid entry. Please enter a valid entry: (y) ");
					readyToPlay = Console.ReadLine();

				}

			}

			do
			{

                StreamWriter writer = new StreamWriter(@"Records.txt"); //this would declare 'writer', and will be used to write text into the Records.txt file

                bet = 0;
                dealerCardNo1 = 0;
                dealerCardNo2 = 0;
                dealerTotalValue = 0;
                playerCardNo1 = 0;
                playerCardNo2 = 0;
                aceEqualsWhat = 0;
                playerTotalValue = 0;
                playerOtherTotalValue = 0;
                nextPlayerCard = 0;
                nextDealerCard = 0;

                Console.WriteLine("\nOk! Then let's play."); //game starts
				delay();

                if (stars == 0)
                {

                    Console.WriteLine("\nYou're stars have been restored to you!");
                    stars = 10;

                }

                else
                {

                    Console.Write("\nYour stars: " + stars); 
                    writer.WriteLine("\n    *  So, You started with " + stars + " stars");

                }
				
				delay();

				bet = 0;

				do
				{

                    Console.Write("\nHow much are you willing to bet? ");
                randomInput:
                    string randomInput = Console.ReadLine();
                    int numCheck;

                    if (int.TryParse(randomInput, out numCheck)) 
                    {

                        bet = Convert.ToDouble(randomInput);

                    }

                    else 
                    {

                        Console.WriteLine("\nInvalid entry. Please enter a number: (1 - " + stars + ") ");
                        goto randomInput;

                    }

                    if ((bet > stars) || (bet < 1))
                    {

                        Console.Write("Invalid value. Please enter an amount you can bet with: (1 - " + stars + ") ");
                        goto randomInput;

                    }

                } while ((bet > stars) || (bet < 1)); 

                writer.WriteLine("\n    *  You bet " + bet + " stars");
                stars -= bet;

				delay();

                Random rnd = new Random();
                dealerCardNo1 = rnd.Next(1, 11); 
                dealerCardNo2 = rnd.Next(1, 11); 
                playerCardNo1 = rnd.Next(1, 11); 
                playerCardNo2 = rnd.Next(1, 11); 

                Console.WriteLine("\nThe dealer has drawn the cards."); 

                delay();

				if ((dealerCardNo1 == 1) || (dealerCardNo1 == 11))
				{

					Console.Write("\nThe dealer has an Ace and a faced-down card.");
					Console.WriteLine("\nTotal value: " + dealerCardNo1 + ".");
                    writer.Write("\n    *  The dealer draws the cards, and gets an Ace (he chooses " + dealerCardNo1 + ") and a faced-down card.");
                    writer.WriteLine("\n     = Total value: " + dealerCardNo1 + ".");

                    delay();

                }

				else
				{

					Console.Write("\nThe dealer has a(n) " + dealerCardNo1 + " and a faced-down card.");
					Console.WriteLine("\nTotal value: " + dealerCardNo1 + ".");
                    writer.Write("\n    *  The dealer draws the cards, and gets an a(n) " + dealerCardNo1 + " and a faced-down card.");
                    writer.WriteLine("\n     = Total value: " + dealerCardNo1 + ".");

                    delay();

                }

				if (((playerCardNo1 == 1) || (playerCardNo1 == 11)) && ((playerCardNo2 != 1) || (playerCardNo2 != 11)))
				{

					Console.Write("\nYou have an Ace and a(n) " + playerCardNo2 + ".");
                    writer.Write("\n    *  You get an Ace and a(n) " + playerCardNo2 + ".");

                    AceEqualsWhat(ref aceEqualsWhat);

					if (aceEqualsWhat == 1)
					{

						playerCardNo1 = 1;

					}

					else
					{

						playerCardNo1 = 11;

					}

                    writer.Write("\n     = You choose " + playerCardNo1 + " for you Ace");

                }

				else if (((playerCardNo1 != 1) || (playerCardNo1 != 11)) && ((playerCardNo2 == 1) || (playerCardNo2 == 11)))
				{

					Console.Write("\nYou have a(n) " + playerCardNo1 + " and an Ace.");
                    writer.Write("\n    *  You get an a(n) " + playerCardNo1 + " and an Ace.");

                    AceEqualsWhat(ref aceEqualsWhat);

                    if (aceEqualsWhat == 1)
					{

						playerCardNo2 = 1;

					}

					else
					{

						playerCardNo2 = 11;

					}

                    writer.Write("\n     = You choose " + playerCardNo2 + " for you Ace");

                }

				else if (((playerCardNo1 == 1) || (playerCardNo1 == 11)) && ((playerCardNo2 == 1) || (playerCardNo2 == 11)))
				{

					Console.Write("\nYou have two Aces.");
                    writer.Write("\n    *  You get two Aces.");

                    AceEqualsWhat(ref aceEqualsWhat);

                    if (aceEqualsWhat == 1)
					{

						playerCardNo1 = 1;

					}

					else
					{

						playerCardNo1 = 11;

					}

                    AceEqualsWhat(ref aceEqualsWhat);

                    if (aceEqualsWhat == 1)
					{

						playerCardNo2 = 1;

					}

					else
					{

						playerCardNo2 = 11;

					}

                    writer.Write("\n     = You choose " + playerCardNo1 + " and " + playerCardNo2 + " for your Aces");

                }

				else
				{

					Console.Write("\nYou have a(n) " + playerCardNo1 + " and a(n) " + playerCardNo2 + ".");
                    writer.Write("\n    *  You get a(n) " + playerCardNo1 + " and a(n) " + playerCardNo2 + ".");

                }

				dealerTotalValue = dealerCardNo1 + dealerCardNo2; 
				playerTotalValue = playerCardNo1 + playerCardNo2; 

				Console.WriteLine("\nTotal value: " + playerTotalValue + "."); 
                writer.WriteLine("\n     = Total value: " + playerTotalValue + ".");

                if (playerTotalValue == 21) 
                {

                    Console.WriteLine("\nBLACKJACK!");
                    writer.Write("\n    *  You get a Blackjack!");
                    bet *= 1.25;

                    dealerTotalValue = 17;

                }

                else if (((dealerCardNo1 == 10) || (dealerCardNo1 == 11)) && ((playerTotalValue != 21))) 
                {

                    Console.Write("\nDo you want to surrender? (y/n) "); 
                    surrender = Console.ReadLine();

					while ((!surrender.Equals("y")) && (!surrender.Equals("Y")) && (!surrender.Equals("n")) && (!surrender.Equals("N"))) 
					{

						Console.Write("\nInvalid entry. Please enter a valid entry: (y/n) ");
						surrender = Console.ReadLine();

					}

				}

				if ((playerTotalValue != 21) && ((!"y".Equals(surrender)) && (!"Y".Equals(surrender)))) 
				{

					do
					{

						if ((dealerCardNo1 == 11) && (insuranceBet <= stars) && (nextPlayerCard == 0)) 
						{

							delay();

							Console.Write("\nDo you want to insure your cards? (y/n) ");
							insurance = Console.ReadLine();

							while ((!"Y".Equals(insurance)) && (!"y".Equals(insurance)) && (!"N".Equals(insurance)) && (!"n".Equals(insurance))) 
							{

								Console.Write("\nInvalid entry. Please enter a valid entry: (y/n) ");
								insurance = Console.ReadLine();

							}

							if (("y".Equals(insurance)) || ("Y".Equals(insurance))) 
							{

								stars -= insuranceBet;

                                Console.Write("\nDealer's total value: " + dealerTotalValue + ".");

                                delay();

								if (dealerTotalValue == 21) 
								{

									stars += insuranceBet;

									Console.Write("\nYou win the bet " + name + "!");

									Console.Write("\nYour stars: " + stars);

                                    writer.Write("\n    *  You used insurance, and won the bet; because the dealer's total value is " + dealerTotalValue + ".");
                                    writer.WriteLine("\n     = Your stars: " + stars);

                                }

								else 
								{

									Console.Write("\nYou lose the bet " + "!");

									Console.Write("\nYour stars: " + stars);

                                    writer.Write("\n    *  You used insurance, and lost the bet; because the dealer's total value is " + dealerTotalValue + ".");
                                    writer.WriteLine("\n     = Your stars: " + stars);

                                }

							}

						}

						delay();

						if (((playerCardNo1 == playerCardNo2) && (dealerTotalValue != 21)) && (stars >= bet)) 
						{

							Console.Write("Do you want to split? (y/n) ");
							split = Console.ReadLine();

							while ((!split.Equals("Y")) && (!split.Equals("y")) && (!split.Equals("N")) && (!split.Equals("n")))
							{

								Console.Write("\nInvalid entry. Please enter a valid entry: (y/n) ");
								split = Console.ReadLine();

							}

							if ((split.Equals("y")) || (split.Equals("Y"))) 
							{

								playerTotalValue -= playerCardNo1;

								playerOtherTotalValue += playerCardNo1;

								bet += bet;

                                writer.Write("\n    *  You split your card hand.");
                                writer.Write("\n       For your first hand:");

                                Console.Write("\nThis is your first hand."); 

								delay();

								do
								{

									if ((stars >= bet) && (nextPlayerCard == 0)) 
									{

										Console.Write("\nDo you want to double down? (y/n) "); 
										doubleDown = Console.ReadLine();

										while ((!doubleDown.Equals("Y")) && (!doubleDown.Equals("y")) && (!doubleDown.Equals("N")) && (!doubleDown.Equals("n"))) 
										{

											Console.Write("\nInvalid entry. Please enter a valid entry: (y/n) ");
											doubleDown = Console.ReadLine();

										}

									}

									delay();

									if (("Y".Equals(doubleDown)) || ("y".Equals(doubleDown))) 
									{

										stars -= bet;

										bet += bet;

                                        nextPlayerCard = rnd.Next(1, 11); 

										if ((nextPlayerCard == 1) || (nextPlayerCard == 11))
										{

											Console.Write("\nYou get an Ace!");
                                            
                                            AceEqualsWhat(ref aceEqualsWhat);

											if (aceEqualsWhat == 1)
											{

												nextPlayerCard = 1;

											}

											else
											{

												nextPlayerCard = 11;

											}

                                            writer.Write("\n     = You double down, and you get an Ace!" + "\n     = You chose a value of " + nextPlayerCard + " for your Ace.");

										}

										else
										{

											Console.Write("\nYou get a(n) " + nextPlayerCard + ".");
                                            writer.Write("\n     = You double down, and you get a(n) " + nextPlayerCard + ".");

                                        }

                                        playerTotalValue += nextPlayerCard;
                                        Console.Write("\nTotal value: " + playerTotalValue); 
                                        writer.WriteLine("\n     = Total value: " + playerTotalValue);

                                        delay();

									}

									else 
									{

										Console.Write("\nHit or stand? (h/s) "); 
										hitOrStand = Console.ReadLine();

										while ((!hitOrStand.Equals("H")) && (!hitOrStand.Equals("S")) && (!hitOrStand.Equals("h")) && (!hitOrStand.Equals("s"))) 
										{

											Console.Write("\nInvalid entry. Please enter a valid entry: (h/s) ");
											hitOrStand = Console.ReadLine();

										}

										delay();

										if ((hitOrStand.Equals("h")) || (hitOrStand.Equals("H"))) 
										{

                                            writer.Write("\n    *  You hit!");

                                            nextPlayerCard = rnd.Next(1, 11); 

                                            if ((nextPlayerCard == 1) || (nextPlayerCard == 11))
											{

												Console.Write("\nYou get an Ace!");

                                                AceEqualsWhat(ref aceEqualsWhat);

                                                if (aceEqualsWhat == 1)
												{

													nextPlayerCard = 1;

												}

												else
												{

													nextPlayerCard = 11;

												}

                                                writer.Write("\n     = You get an Ace, and chose a value of " + nextPlayerCard + " for your Ace.");

                                            }

											else
											{

												Console.Write("\nYou get a(n) " + nextPlayerCard + ".");
                                                writer.Write("\n     = You get a(n) " + nextPlayerCard + ".");

                                            }

										playerTotalValue += nextPlayerCard;
										Console.WriteLine("\nTotal value: " + playerTotalValue + "."); 
                                        writer.WriteLine("\n     = Total value: " + playerTotalValue + ".");

                                        }

									}

								} while (((("h".Equals(hitOrStand)) || ("H".Equals(hitOrStand))) && (playerTotalValue < 21)) && ((!"Y".Equals(doubleDown)) && (!"y".Equals(doubleDown))));

								delay();

								nextPlayerCard = 0;

                                writer.Write("\n       For your second hand:");
                                Console.Write("\nThis is your second hand.");

								delay();

								do
								{

									if ((stars >= bet) && (nextPlayerCard == 0))
									{

										Console.Write("\nDo you want to double down? (y/n) ");
										doubleDown = Console.ReadLine();

										while ((!doubleDown.Equals("Y")) && (!doubleDown.Equals("y")) && (!doubleDown.Equals("N")) && (!doubleDown.Equals("n")))
										{

											Console.Write("\nInvalid entry. Please enter a valid entry: (y/n) ");
											doubleDown = Console.ReadLine();

										}

									}

									delay();

									if (("Y".Equals(doubleDown)) || ("y".Equals(doubleDown)))
									{

										stars -= bet;

										bet += bet;

										nextPlayerCard = rnd.Next(1, 11);

										if ((nextPlayerCard == 1) || (nextPlayerCard == 11))
										{

											Console.Write("\nYou get an Ace!");

                                            AceEqualsWhat(ref aceEqualsWhat);

                                            if (aceEqualsWhat == 1)
											{

												nextPlayerCard = 1;

											}

											else
											{

												nextPlayerCard = 11;

											}

                                            writer.Write("\n     = You double down, and you get an Ace!" + "\n     = You chose a value of " + nextPlayerCard + " for your Ace.");

                                        }

										else
										{

											Console.Write("\nYou get a(n) " + nextPlayerCard + ".");
                                            writer.Write("\n     = You double down, and you get a(n) " + nextPlayerCard + ".");

                                        }

                                        playerOtherTotalValue += nextPlayerCard;
                                        Console.Write("\nTotal value: " + playerOtherTotalValue);
                                        writer.WriteLine("\n     = Total value: " + playerOtherTotalValue);

                                        delay();

									}

									else
									{

										Console.Write("\nHit or stand? (h/s) ");
										hitOrStand = Console.ReadLine();

										while ((!hitOrStand.Equals("H")) && (!hitOrStand.Equals("S")) && (!hitOrStand.Equals("h")) && (!hitOrStand.Equals("s")))
										{

											Console.Write("\nInvalid entry. Please enter a valid entry: (h/s) ");
											hitOrStand = Console.ReadLine();

										}

										delay();

										if ((hitOrStand.Equals("h")) || (hitOrStand.Equals("H")))
										{

                                            writer.Write("\n    *  You hit!");

                                            nextPlayerCard = rnd.Next(1, 11);

                                            if ((nextPlayerCard == 1) || (nextPlayerCard == 11))
											{

												Console.Write("\nYou get an Ace!");

                                                AceEqualsWhat(ref aceEqualsWhat);

                                                if (aceEqualsWhat == 1)
												{

													nextPlayerCard = 1;

												}

												else
												{

													nextPlayerCard = 11;

												}

                                                writer.Write("\n     = You get an Ace!" + "\n     = You chose a value of " + nextPlayerCard + " for your Ace.");

                                            }

											else
											{

												Console.Write("\nYou get a(n) " + nextPlayerCard + ".");
                                                writer.Write("\n     = You get a(n) " + nextPlayerCard + ".");

                                            }

										playerOtherTotalValue += nextPlayerCard;
										Console.WriteLine("\nTotal value: " + playerOtherTotalValue + ".");
                                        writer.WriteLine("\n     = Total value: " + playerOtherTotalValue + ".");

                                        }

									}

								} while (((("h".Equals(hitOrStand)) || ("H".Equals(hitOrStand))) && (playerTotalValue < 21)) && ((!"Y".Equals(doubleDown)) && (!"y".Equals(doubleDown))));

							}

						}

						else if (dealerTotalValue != 21) 
						{

							delay();

							if ((stars >= bet) && (nextPlayerCard == 0))
							{

								Console.Write("\nDo you want to double down? (y/n) ");
								doubleDown = Console.ReadLine();

								while ((!doubleDown.Equals("Y")) && (!doubleDown.Equals("y")) && (!doubleDown.Equals("N")) && (!doubleDown.Equals("n")))
								{

									Console.Write("\nInvalid entry. Please enter a valid entry: (y/n) ");
									doubleDown = Console.ReadLine();

								}

							}

							delay();

							if (("Y".Equals(doubleDown)) || ("y".Equals(doubleDown)))
							{

                                stars -= bet;

								bet += bet;

								nextPlayerCard = rnd.Next(1, 11);

								if ((nextPlayerCard == 1) || (nextPlayerCard == 11))
								{

									Console.Write("\nYou get an Ace!");

									AceEqualsWhat(ref aceEqualsWhat);

									if (aceEqualsWhat == 1)
									{

										nextPlayerCard = 1;

									}

									else
									{

										nextPlayerCard = 11;

									}

                                    writer.Write("\n     = You double down, and you get an Ace!" + "\n     = You chose a value of " + nextPlayerCard + " for your Ace.");

                                }

								else
								{

									Console.Write("\nYou get a(n) " + nextPlayerCard + ".");
                                    writer.Write("\n     = You double down, and you get a(n) " + nextPlayerCard + ".");

                                }

                                playerTotalValue += nextPlayerCard;
                                Console.WriteLine("\nTotal value: " + playerTotalValue + ".");
                                writer.WriteLine("\n     = Total value: " + playerTotalValue + ".");

                            }

							else
							{

								Console.Write("\nHit or stand? (h/s) ");
								hitOrStand = Console.ReadLine();

								while ((!hitOrStand.Equals("H")) && (!hitOrStand.Equals("S")) && (!hitOrStand.Equals("h")) && (!hitOrStand.Equals("s")))
								{

									Console.Write("\nInvalid entry. Please enter a valid entry: (h/s) ");
									hitOrStand = Console.ReadLine();

								}

								delay();

								if ((hitOrStand.Equals("h")) || (hitOrStand.Equals("H")))
								{

                                    writer.Write("\n    *  You hit!");

                                    nextPlayerCard = rnd.Next(1, 11);

                                    if ((nextPlayerCard == 1) || (nextPlayerCard == 11))
									{

										Console.Write("\nYou get an Ace!");

                                        AceEqualsWhat(ref aceEqualsWhat);

                                        if (aceEqualsWhat == 1)
										{

											nextPlayerCard = 1;

										}

										else
										{

											nextPlayerCard = 11;

										}

                                        writer.Write("\n     = You get an Ace!" + "\n     = You chose a value of " + nextPlayerCard + " for your Ace.");

                                    }

									else
									{

										Console.Write("\nYou get a(n) " + nextPlayerCard + ".");
                                        writer.Write("\n     = You get a(n) " + nextPlayerCard + ".");

                                    }

								playerTotalValue += nextPlayerCard;
								Console.WriteLine("\nTotal value: " + playerTotalValue + ".");
                                writer.WriteLine("\n     = Total value: " + playerTotalValue + ".");

                                }

							}

						}

					} while (((("h".Equals(hitOrStand)) || ("H".Equals(hitOrStand))) && (playerTotalValue < 21)) && ((!"Y".Equals(doubleDown)) && (!"y".Equals(doubleDown))));

				}

				delay();

                while ((dealerTotalValue < 17) && ((playerTotalValue < 22) || ((playerOtherTotalValue < 22) && (playerOtherTotalValue > 0))) && ((!"Y".Equals(surrender) && (!"y".Equals(surrender)))))
                {

                    
                    if (nextDealerCard == 0)
                    {

                        Console.WriteLine("\nThe dealer already has a(n) " + dealerCardNo1 + " and a faced-down card with value " + dealerCardNo2 + ".");
                        writer.Write("\n    *  The dealer already has a(n) " + dealerCardNo1 + " and a faced-down card with value " + dealerCardNo2 + ".");
                        Console.Write("\nTotal value: " + dealerTotalValue + ".");
                        writer.Write("\n     = Total value: " + dealerTotalValue + ".");

                    }

                    else
                    {

                        nextDealerCard = rnd.Next(1, 11);
                        Console.WriteLine("\nThe dealer draws again!");
                        writer.Write("\n    *  The dealer draws again!");

                    }

                    nextDealerCard = rnd.Next(1, 11);

                    delay();

                    if ((nextDealerCard == 1) || (nextDealerCard == 11))
					{

                        if (dealerTotalValue + 11 <= 21)
                        {

                            nextDealerCard = 11;

                        }

                        else if (dealerTotalValue + 11 > 21)
                        {

                            nextDealerCard = 1;

                        }

                        Console.Write("\nThe dealer now gets an Ace!" + "\nThe dealer chooses a value of " + nextDealerCard);
                        writer.Write("\n     = The dealer gets an Ace and, chooses a value of " + nextDealerCard);

                    }

					else
					{

						Console.Write("\nThe dealer now gets a(n) " + nextDealerCard + ".");
                        writer.Write("\n     = The dealer gets a(n) " + nextDealerCard + ".");

                    }

					dealerTotalValue += nextDealerCard;
					Console.WriteLine("\nTotal value: " + dealerTotalValue + ".");
                    writer.WriteLine("\n     = Total value: " + dealerTotalValue + ".");

                    delay();

				}

				if (("y".Equals(surrender)) || ("Y".Equals(surrender))) 
				{

					Console.WriteLine("You lose half you bet.");
                    writer.WriteLine("    *  You surrendered, and lost half your bet");

                    writer.Close(); //this is used to close the Records.txt file
                    ToSeekRecords(); //this is used to call the method 'ToSeekRecords', in which the user would be asked if they want to review the game

                    bet *= 0.5;
					stars += bet;

					delay();

				}

				else if ((dealerTotalValue == playerTotalValue) || (dealerTotalValue == playerOtherTotalValue)) 
				{

					if (("Y".Equals(split)) || ("y".Equals(split)))
					{

						if ((dealerTotalValue == playerTotalValue) && (dealerTotalValue == playerOtherTotalValue)) 
						{

							Console.WriteLine("\nPUSH FOR BOTH HANDS!");
                            writer.WriteLine("\n    *  Both hands were pushed.");

                            writer.Close(); //this is used to close the Records.txt file
                            ToSeekRecords(); //this is used to call the method 'ToSeekRecords', in which the user would be asked if they want to review the game

                            stars += bet;

						}

						else if (dealerTotalValue == playerTotalValue) 
						{

							Console.WriteLine("\nPUSH FOR HAND 1!");
                            writer.WriteLine("\n    *  The first hand was pushed.");

                            writer.Close(); //this is used to close the Records.txt file
                            ToSeekRecords(); //this is used to call the method 'ToSeekRecords', in which the user would be asked if they want to review the game

                            stars += (bet / 2);

						}

						else if (dealerTotalValue == playerOtherTotalValue) 
						{

							Console.WriteLine("\nPUSH FOR HAND 2!");
                            writer.WriteLine("\n    *  The second hand was pushed.");

                            writer.Close(); //this is used to close the Records.txt file
                            ToSeekRecords(); //this is used to call the method 'ToSeekRecords', in which the user would be asked if they want to review the game

                            stars += (bet / 2);

						}
					}

					else if (dealerTotalValue == playerTotalValue) 
					{

						Console.WriteLine("\nPUSH!");
                        writer.WriteLine("\n    *  The hand was pushed.");

                        writer.Close(); //this is used to close the Records.txt file
                        ToSeekRecords(); //this is used to call the method 'ToSeekRecords', in which the user would be asked if they want to review the game

                        stars += bet;

					}

					delay();

				}

				else if ((((dealerTotalValue > playerTotalValue) || ((dealerTotalValue > playerOtherTotalValue) && (playerOtherTotalValue != 0))) && (dealerTotalValue < 22)) || ((playerTotalValue > 21) || (playerOtherTotalValue > 21)))
				{

					if (("Y".Equals(split)) || ("y".Equals(split)))
					{

						if (((dealerTotalValue > playerTotalValue) && (dealerTotalValue > playerOtherTotalValue)) || ((playerTotalValue > 21) && (playerOtherTotalValue > 21))) 
						{

							Console.WriteLine("\nYou lose both your hands " + name + "!");
                            writer.WriteLine("\n    *  You lose both your hands.");

                            writer.Close(); //this is used to close the Records.txt file
                            ToSeekRecords(); //this is used to call the method 'ToSeekRecords', in which the user would be asked if they want to review the game

                        }

						else if (((dealerTotalValue > playerTotalValue)) || (playerTotalValue > 21)) 
						{

							Console.WriteLine("\nYou lose your first hand " + name + "!");
                            writer.WriteLine("\n    *  You lose your first hand.");

                            writer.Close(); //this is used to close the Records.txt file
                            ToSeekRecords(); //this is used to call the method 'ToSeekRecords', in which the user would be asked if they want to review the game

                            stars += (bet / 2);

						}

						else if (((dealerTotalValue > playerOtherTotalValue)) || (playerOtherTotalValue > 21)) 
						{

							Console.WriteLine("\nYou lose you second hand " + name + "!");
                            writer.WriteLine("\n    *  You lose your second hand.");

                            writer.Close(); //this is used to close the Records.txt file
                            ToSeekRecords(); //this is used to call the method 'ToSeekRecords', in which the user would be asked if they want to review the game

                            stars += (bet / 2);

						}

					}

					else 
					{

						Console.WriteLine("\nYou lose the game " + name + "!");
                        writer.WriteLine("\nThat's how you lost the game " + name + "! :(");

                        writer.Close(); //this is used to close the Records.txt file
                        ToSeekRecords(); //this is used to call the method 'ToSeekRecords', in which the user would be asked if they want to review the game

                    }

				}

				else 
				{

					Console.WriteLine("\nYou win, " + name + "!");
                    writer.WriteLine("\nThat's how you won the game " + name + "! :D");

                    writer.Close(); //this is used to close the Records.txt file
                    ToSeekRecords(); //this is used to call the method 'ToSeekRecords', in which the user would be asked if they want to review the game

                    stars += (bet * 2);

                }

				Console.Write("\nDo you want to play again? (y/n) "); 
				playAgain = Console.ReadLine();

				while ((!playAgain.Equals("Y")) && (!playAgain.Equals("y")) && (!playAgain.Equals("N")) && (!playAgain.Equals("n"))) 
				{

					Console.Write("\nInvalid entry. Please enter a valid entry: (y/n) ");
					playAgain = Console.ReadLine();

				}

			} while ((playAgain.Equals("Y")) || (playAgain.Equals("y")));

        }

	}
}