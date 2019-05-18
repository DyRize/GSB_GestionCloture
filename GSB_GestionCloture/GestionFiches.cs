// <copyright file="GestionFiches.cs" company="Dylan LE FLOUR">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace GSB_GestionCloture
{
    using System;

    /// <summary>
    /// Classe de gestion des fiches.
    /// </summary>
    public class GestionFiches
    {
        private static string etatSaisie = "CR";
        private static string etatCloturee = "CL";
        private static string etatValidee = "VA";
        private static string etatRembourse = "RB";
        private static int jourFinCampagne = 10;
        private static int jourMiseEnPaiement = 20;
        private static string updateQuery = "UPDATE fichefrais SET idEtat = @idEtat WHERE idEtat = @idEtatActuel AND mois = @mois";
        private static string[] key = { "@idEtat", "@idEtatActuel", "@mois" };
        private static BDD bdd = new BDD();

        /// <summary>
        /// Passe à l'état cloturé les fiches du mois précédent.
        /// </summary>
        public static void ClotureFiches()
        {
            if (GestionDates.Entre(01, jourFinCampagne))
            {
                string[] valeur = { etatCloturee, etatSaisie, GetFormatDateFicheFrais() };
                bdd.AdminQuery(updateQuery, valeur, key);
            }
        }

        /// <summary>
        /// Passe à l'état remboursé les fiches validée du mois précédent.
        /// </summary>
        public static void RembourseFiches()
        {
            if (GestionDates.Entre(jourMiseEnPaiement, 31))
            {
                string[] valeur = { etatRembourse, etatValidee, GetFormatDateFicheFrais() };
                bdd.AdminQuery(updateQuery, valeur, key);
            }
        }

        /// <summary>
        /// Retourne le format du champ mois de la base.
        /// </summary>
        /// <returns>Année + mois.</returns>
        public static string GetFormatDateFicheFrais()
        {
            string mois = GestionDates.GetMoisPrecedent();
            int annee = DateTime.Today.Year;
            if (mois == "12")
            {
                annee -= 1;
            }

            string format = annee + mois;
            return format;
        }
    }
}
