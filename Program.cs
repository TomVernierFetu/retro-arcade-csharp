using System;

namespace TC1A_TP3
{
    // TP3.2 - Borne d'Arcade BTS SIO
    // Auteur : Tom Vernier-Fétu
    internal class TP3_2_Arcade
    {
        // Variables globales du joueur et du score
        static string pseudoJoueur = "Joueur";
        static int scoreCumule = 0;
        static Random rnd = new Random();

        // Jeu 1 : Le nombre mystère
        static void Jeu1_NombreMystere()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("+---------------------------------------------+");
            Console.WriteLine("|               NOMBRE MYSTERE                |");
            Console.WriteLine("+---------------------------------------------+");
            Console.ResetColor();

            Console.WriteLine("\nLe but du jeu est de découvrir un nombre en maximum 7 essais.");
            Console.WriteLine("Le nombre mystère est compris entre 1 et 100.");

            int nombreSecret = rnd.Next(1, 101);
            int essai = 1;
            bool trouve = false;
            int pointsGagnes = 0;

            while (essai <= 7 && !trouve)
            {
                Console.Write("\nQuelle est ta proposition n°" + essai + " ? (entre 1 et 100) : ");
                string saisie = Console.ReadLine();
                int proposition;

                if (!int.TryParse(saisie, out proposition) || proposition < 1 || proposition > 100)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Saisie invalide ! Vous devez entrer un entier entre 1 et 100.");
                    Console.ResetColor();
                    continue; // Ne consomme pas d'essai sur faute de frappe
                }

                if (proposition == nombreSecret)
                {
                    trouve = true;
                    // Barème : 70 points au 1er coup, puis -10 par essai supplémentaire
                    pointsGagnes = 70 - ((essai - 1) * 10);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nBravo " + pseudoJoueur + " ! Tu as trouvé en " + essai + " essai(s).");
                    Console.WriteLine("Tu marques " + pointsGagnes + " points !");
                    Console.ResetColor();
                }
                else if (proposition > nombreSecret)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Le nombre mystère est plus petit");
                    Console.ResetColor();
                    essai++;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Le nombre mystère est plus grand");
                    Console.ResetColor();
                    essai++;
                }
            }

            if (!trouve)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nDommage ! Vous avez épuisé vos 7 essais.");
                Console.WriteLine("Le nombre mystère était : " + nombreSecret);
                Console.ResetColor();
            }

            scoreCumule += pointsGagnes;
            Console.WriteLine("\nAppuyez sur une touche pour revenir à la borne...");
            Console.ReadKey(true);
        }

        // Jeu 2 : La station spatiale
        static void Jeu2_StationSpatiale()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("+---------------------------------------------+");
            Console.WriteLine("|              STATION SPATIALE               |");
            Console.WriteLine("+---------------------------------------------+");
            Console.ResetColor();

            Console.WriteLine("\nLe but du jeu est de rejoindre la station spatiale avant de manquer de carburant.");

            int distanceRestante = 100;
            int carburant = 50;
            bool partieEnCours = true;
            bool victoire = false;

            while (partieEnCours)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\nDistance restante : " + distanceRestante);
                Console.WriteLine("Carburant restant : " + carburant);
                Console.ResetColor();

                Console.WriteLine("\n1 - Petite poussée   - Économique (distance 10 pour 2 carburant)");
                Console.WriteLine("2 - Poussée moyenne  - Normal     (distance 20 pour 5 carburant)");
                Console.WriteLine("3 - Grande poussée   - Turbo      (distance 35 pour 12 carburant)");
                Console.Write("Quelle poussée choisis-tu ? (1, 2 ou 3) : ");

                string choixPoussee = Console.ReadLine();
                int gainDist = 0;
                int coutCarb = 0;

                switch (choixPoussee)
                {
                    case "1": gainDist = 10; coutCarb = 2;  break;
                    case "2": gainDist = 20; coutCarb = 5;  break;
                    case "3": gainDist = 35; coutCarb = 12; break;
                    default:
                        Console.WriteLine("Poussée inconnue ! Maintien des réacteurs.");
                        continue;
                }

                // Consommation et avancée
                carburant -= coutCarb;
                distanceRestante -= gainDist;
                if (distanceRestante < 0) distanceRestante = 0;

                // Tirage d'un événement aléatoire spatial (1 à 4)
                int aleaEvenement = rnd.Next(1, 5);
                Console.WriteLine();

                switch (aleaEvenement)
                {
                    case 1:
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("Une attraction gravitationnelle te fait avancer de 20 !");
                        Console.ResetColor();
                        distanceRestante -= 20;
                        if (distanceRestante < 0) distanceRestante = 0;
                        break;

                    case 2:
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("Tu croises une pluie d'astéroïdes. Tu perds 5 unités de carburant !");
                        Console.ResetColor();
                        carburant -= 5;
                        break;

                    case 3:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Tu viens d'être absorbé par un trou noir. :(");
                        Console.WriteLine("Fin de partie. Tu as perdu.");
                        Console.ResetColor();
                        partieEnCours = false;
                        break;

                    case 4:
                        Console.WriteLine("Aucun péril en vue. Un peu de répit.");
                        break;
                }

                // Vérification des conditions de victoire ou défaite
                if (distanceRestante <= 0)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nTu es arrivé à destination. Bravo " + pseudoJoueur + " !");
                    Console.ResetColor();
                    victoire = true;
                    partieEnCours = false;
                }
                else if (carburant <= 0 && partieEnCours)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nPanne de carburant dans le vide spatial... Mission échouée !");
                    Console.ResetColor();
                    partieEnCours = false;
                }
            }

            if (victoire)
            {
                int pointsGagnes = 50 + (carburant * 2);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Score bonus carburant : +" + pointsGagnes + " points !");
                Console.ResetColor();
                scoreCumule += pointsGagnes;
            }

            Console.WriteLine("\nAppuyez sur une touche pour revenir à la borne...");
            Console.ReadKey(true);
        }

        // Jeu 3 : Le tir de précision
        static void Jeu3_TirDePrecision()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("+---------------------------------------------+");
            Console.WriteLine("|              TIR DE PRECISION               |");
            Console.WriteLine("+---------------------------------------------+");
            Console.ResetColor();

            Console.WriteLine("\nLe but du jeu est de tirer au plus près d'une cible située entre 1 et 100 mètres.");
            Console.WriteLine("Elle bouge à chaque tir. Vous avez 5 tirs pour marquer un maximum de points.");

            int scorePartie = 0;

            for (int tir = 1; tir <= 5; tir++)
            {
                Console.WriteLine("\n***** Tir n°" + tir + " *****");
                int cible = rnd.Next(1, 101); // Distance aléatoire de la cible

                Console.Write("A quelle distance tires-tu ? (entre 1 et 100) : ");
                string saisie = Console.ReadLine();
                int tirJoueur;

                if (!int.TryParse(saisie, out tirJoueur) || tirJoueur < 1 || tirJoueur > 100)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Tir hors-champ ! Tir manqué.");
                    Console.ResetColor();
                    continue;
                }

                int ecart = Math.Abs(tirJoueur - cible);
                Console.WriteLine("Distance de la cible : " + cible + " mètres (écart : " + ecart + "m)");

                int points = 0;
                // Barème officiel du sujet
                if (ecart == 0)
                {
                    points = 75;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Dans le mille. Quel champion !! (+75 pts)");
                }
                else if (ecart <= 5)
                {
                    points = 50;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Félicitations ! Quel tireur ! (+50 pts)");
                }
                else if (ecart <= 15)
                {
                    points = 40;
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Beau tir ! (+40 pts)");
                }
                else if (ecart <= 30)
                {
                    points = 30;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Pas trop mal (+30 pts)");
                }
                else if (ecart <= 45)
                {
                    points = 20;
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("Vraiment moyen (+20 pts)");
                }
                else if (ecart <= 60)
                {
                    points = 10;
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("Pas terrible (+10 pts)");
                }
                else if (ecart <= 75)
                {
                    points = 5;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Raté (+5 pts)");
                }
                else
                {
                    points = 0;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Complètement raté (0 pt)");
                }

                Console.ResetColor();
                scorePartie += points;
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n**** " + pseudoJoueur + ", tu as marqué " + scorePartie + " points au tir ! ****");
            Console.ResetColor();

            scoreCumule += scorePartie;
            Console.WriteLine("\nAppuyez sur une touche pour revenir à la borne...");
            Console.ReadKey(true);
        }

        // ---------------------------------------------------------------------
        // JEU 4 : LA QUÊTE (SURVIVAL QUEST - 10 étapes, Vie 100, Nourriture 10, Pièces 20)
        // ---------------------------------------------------------------------
        static void Jeu4_LaQuete()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("+---------------------------------------------+");
            Console.WriteLine("|               SURVIVAL QUEST                |");
            Console.WriteLine("+---------------------------------------------+");
            Console.ResetColor();

            Console.WriteLine("\n" + pseudoJoueur + ", ta mission : traverser les 10 étapes d'un environnement hostile pour atteindre le refuge.");

            int vie = 100;
            int nourriture = 10;
            int pieces = 20;
            int potions = 0;
            int etape = 1;

            while (etape <= 10 && vie > 0)
            {
                // En-tête HUD
                Console.WriteLine("\n+-----------------------------------+");
                Console.WriteLine("| SURVIVAL QUEST                    |");
                Console.WriteLine("+-----------------------------------+");
                Console.WriteLine("| Explorateur : " + pseudoJoueur);
                Console.WriteLine("| Vie         : " + vie);
                Console.WriteLine("| Nourriture  : " + nourriture);
                Console.WriteLine("| Pièces      : " + pieces);
                Console.WriteLine("| Potion      : " + potions);
                Console.WriteLine("| Étape       : " + etape + " / 10");
                Console.WriteLine("+-----------------------------------+");

                // Tirage de l'événement aléatoire (1 à 8)
                int evt = rnd.Next(1, 9);

                switch (evt)
                {
                    case 1:
                        Console.WriteLine("\nTu trouves une caisse de provisions !");
                        Console.WriteLine("1 - Manger (+2 nourritures, +10 PV)");
                        Console.WriteLine("2 - Conserver (+10 nourritures)");
                        Console.Write("Votre choix : ");
                        if (Console.ReadLine() == "1")
                        {
                            nourriture += 2;
                            vie = Math.Min(100, vie + 10);
                            Console.WriteLine("Miam ! Tu gagnes 2 nourritures et 10 PV.");
                        }
                        else
                        {
                            nourriture += 10;
                            Console.WriteLine("Prévoyant ! Tu ajoutes 10 nourritures à ton sac.");
                        }
                        break;

                    case 2:
                        Console.WriteLine("\nTu trouves un trésor !");
                        Console.WriteLine("1 - Le prendre (+15 pièces)");
                        Console.WriteLine("2 - Le laisser");
                        Console.Write("Votre choix : ");
                        if (Console.ReadLine() == "1")
                        {
                            pieces += 15;
                            Console.WriteLine("Fortune ! Tu ramasses 15 pièces.");
                        }
                        else
                        {
                            Console.WriteLine("Prudent, tu passes ton chemin.");
                        }
                        break;

                    case 3:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nAïe ! Tu es tombé dans un piège ! Tu perds 20 PV.");
                        Console.ResetColor();
                        vie -= 20;
                        break;

                    case 4:
                        Console.WriteLine("\nUn marchand ambulant te propose son aide :");
                        Console.WriteLine("1 - Acheter 2 nourritures pour 10 pièces");
                        Console.WriteLine("2 - Acheter une potion pour 20 pièces (restaure 25 PV)");
                        Console.WriteLine("3 - Ne rien acheter");
                        Console.Write("Votre choix : ");
                        string choixM = Console.ReadLine();
                        if (choixM == "1" && pieces >= 10)
                        {
                            pieces -= 10;
                            nourriture += 2;
                            Console.WriteLine("Achat réussi : +2 nourritures.");
                        }
                        else if (choixM == "2" && pieces >= 20)
                        {
                            pieces -= 20;
                            potions += 1;
                            Console.WriteLine("Achat réussi : +1 potion.");
                        }
                        else
                        {
                            Console.WriteLine("Vous saluez le marchand et continuez.");
                        }
                        break;

                    case 5:
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("\nUne violente tempête éclate ! Tu perds 1 nourriture et 10 PV.");
                        Console.ResetColor();
                        nourriture = Math.Max(0, nourriture - 1);
                        vie -= 10;
                        break;

                    case 6:
                        Console.WriteLine("\nTu trouves un coffre mystérieux. Veux-tu l'ouvrir ?");
                        Console.WriteLine("1 - Oui");
                        Console.WriteLine("2 - Non");
                        Console.Write("Votre choix : ");
                        if (Console.ReadLine() == "1")
                        {
                            if (rnd.Next(1, 3) == 1)
                            {
                                pieces += 20;
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("Jackpot ! Tu viens de gagner 20 pièces !");
                            }
                            else
                            {
                                vie -= 15;
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Le coffre était piégé, tu perds 15 PV !");
                            }
                            Console.ResetColor();
                        }
                        else
                        {
                            Console.WriteLine("Tu préfères ne pas tenter le diable.");
                        }
                        break;

                    case 7:
                        Console.WriteLine("\nPetite pause. Il ne se passe rien... Tu souffles un peu.");
                        break;

                    case 8:
                        Console.WriteLine("\nTu découvres un raccourci !");
                        Console.WriteLine("1 - Le prendre (risque qui te fait sauter une étape)");
                        Console.WriteLine("2 - Continuer normalement");
                        Console.Write("Votre choix : ");
                        if (Console.ReadLine() == "1")
                        {
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.WriteLine("Tu as pris un risque et gagné une étape !");
                            Console.ResetColor();
                            etape++;
                        }
                        else
                        {
                            Console.WriteLine("Tu restes sur le chemin principal.");
                        }
                        break;
                }

                // Fin de tour : consommation de nourriture
                if (vie > 0)
                {
                    if (nourriture > 0)
                    {
                        nourriture--;
                        Console.WriteLine("Tu manges une ration de survie.");
                    }
                    else
                    {
                        // Famine : perte de 10 PV pour racheter 5 nourritures
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Famine ! Tu n'as plus rien à manger. Tu perds 10 PV pour trouver 5 nourritures.");
                        Console.ResetColor();
                        vie -= 10;
                        nourriture = 5;
                    }

                    // Utilisation de potion si disponible et PV entamés
                    if (potions > 0 && vie <= 75)
                    {
                        Console.Write("Tu as une potion. Veux-tu l'utiliser pour regagner 25 PV ? (1-Oui / 2-Non) : ");
                        if (Console.ReadLine() == "1")
                        {
                            potions--;
                            vie = Math.Min(100, vie + 25);
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Potion consommée ! Vie actuelle : " + vie);
                            Console.ResetColor();
                        }
                    }

                    etape++;
                }
            }

            // Bilan de la quête
            Console.WriteLine();
            if (vie > 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("==================================================");
                Console.WriteLine("     VICTOIRE ! TU AS REJOINT LE REFUGE EN VIE !  ");
                Console.WriteLine("==================================================");
                Console.ResetColor();
                int gainQuete = vie + (pieces * 2);
                Console.WriteLine("Bonus de survie : +" + gainQuete + " points !");
                scoreCumule += gainQuete;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("GAME OVER ! Vos forces vous ont abandonné avant le refuge.");
                Console.ResetColor();
            }

            Console.WriteLine("\nAppuyez sur une touche pour revenir à la borne...");
            Console.ReadKey(true);
        }

        // ---------------------------------------------------------------------
        // JEU 5 : LA MACHINE A SOUS (100 pièces, mise, 3 chiffres 1 à 9, score = pièces / 2)
        // ---------------------------------------------------------------------
        static void Jeu5_MachineASous()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("+---------------------------------------------+");
            Console.WriteLine("|               MACHINE A SOUS                |");
            Console.WriteLine("+---------------------------------------------+");
            Console.ResetColor();

            int pieces = 100; // Le joueur commence avec 100 pièces
            bool continuer = true;

            while (continuer && pieces > 0)
            {
                Console.WriteLine("\nVous avez actuellement " + pieces + " pièces.");
                Console.Write("Combien voulez-vous miser ? ");
                string saisieMise = Console.ReadLine();
                int mise;

                if (!int.TryParse(saisieMise, out mise) || mise <= 0 || mise > pieces)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Mise invalide ! Vous devez miser entre 1 et " + pieces + " pièces.");
                    Console.ResetColor();
                    continue;
                }

                // Tirage de 3 chiffres entre 1 et 9
                int s1 = rnd.Next(1, 10);
                int s2 = rnd.Next(1, 10);
                int s3 = rnd.Next(1, 10);

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\n[" + s1 + "] [" + s2 + "] [" + s3 + "]");
                Console.ResetColor();

                // Analyse du tirage
                if (s1 == s2 && s2 == s3)
                {
                    // 3 chiffres identiques -> gain = mise * 4
                    int gain = mise * 4;
                    pieces += gain;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("INCROYABLE ! Trois symboles identiques !");
                    Console.WriteLine("Vous gagnez " + gain + " pièces !");
                    Console.ResetColor();
                }
                else if (s1 == s2 || s1 == s3 || s2 == s3)
                {
                    // 2 chiffres identiques -> gain = mise * 2
                    int gain = mise * 2;
                    pieces += gain;
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Deux symboles identiques !");
                    Console.WriteLine("Vous gagnez " + gain + " pièces.");
                    Console.ResetColor();
                }
                else
                {
                    // Aucun chiffre identique -> perte de la mise
                    pieces -= mise;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Perdu ! Aucun alignement.");
                    Console.WriteLine("Vous perdez " + mise + " pièces.");
                    Console.ResetColor();
                }

                if (pieces > 0)
                {
                    Console.Write("\nVoulez-vous rejouer ? (1 - Oui / 0 - Non) : ");
                    string rejouer = Console.ReadLine();
                    if (rejouer == "0")
                    {
                        continuer = false;
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nVous êtes fauché ! Plus aucune pièce disponible.");
                    Console.ResetColor();
                }
            }

            // Score converti en points (pièces restantes / 2)
            int scorePartie = pieces / 2;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nPartie terminée. Vos " + pieces + " pièces sont converties en " + scorePartie + " points.");
            Console.ResetColor();

            scoreCumule += scorePartie;
            Console.WriteLine("\nAppuyez sur une touche pour revenir à la borne...");
            Console.ReadKey(true);
        }

        // ---------------------------------------------------------------------
        // MENU PRINCIPAL DE LA BORNE D'ARCADE
        // ---------------------------------------------------------------------
        static void Main(string[] args)
        {
            Console.Title = "ARCADE BTS SIO - BORNE MULTIJEUX";
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Bonjour et bienvenue dans notre console de jeux !");
            Console.ResetColor();

            Console.Write("Quel est ton pseudo pour cette partie ? ");
            string saisiePseudo = Console.ReadLine();
            if (!string.IsNullOrEmpty(saisiePseudo))
            {
                pseudoJoueur = saisiePseudo.Trim();
            }

            string choix = "";

            while (choix != "0")
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("****** " + pseudoJoueur + ", à quel jeu souhaites-tu jouer ? ******");
                Console.WriteLine("========================================");
                Console.WriteLine("            ARCADE BTS SIO              ");
                Console.WriteLine("========================================");
                Console.ResetColor();
                Console.WriteLine("1 - Le nombre mystère");
                Console.WriteLine("2 - La station spatiale");
                Console.WriteLine("3 - Le tir de précision");
                Console.WriteLine("4 - La quête (Survival Quest)");
                Console.WriteLine("5 - La machine à sous");
                Console.WriteLine("6 - Ton score");
                Console.WriteLine("0 - Quitter");
                Console.WriteLine("----------------------------------------");
                Console.Write("Ton choix : ");

                choix = Console.ReadLine();

                switch (choix)
                {
                    case "1": Jeu1_NombreMystere(); break;
                    case "2": Jeu2_StationSpatiale(); break;
                    case "3": Jeu3_TirDePrecision(); break;
                    case "4": Jeu4_LaQuete(); break;
                    case "5": Jeu5_MachineASous(); break;
                    case "6":
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("=== TABLEAU DES SCORES ===");
                        Console.WriteLine("Joueur : " + pseudoJoueur);
                        Console.WriteLine("Score total cumulé : " + scoreCumule + " points !");
                        Console.ResetColor();
                        Console.WriteLine("\nAppuyez sur une touche pour revenir au menu...");
                        Console.ReadKey(true);
                        break;
                    case "0":
                        Console.WriteLine("\nMerci d'avoir joué sur l'Arcade BTS SIO, à bientôt " + pseudoJoueur + " !");
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Choix incorrect, retour au menu...");
                        Console.ResetColor();
                        Console.ReadKey(true);
                        break;
                }
            }
        }
    }
}
