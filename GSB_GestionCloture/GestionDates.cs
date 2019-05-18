// <copyright file="GestionDates.cs" company="Dylan LE FLOUR">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace GSB_GestionCloture
{
    using System;

    /// <summary>
    /// Classe abstraite de gestion des dates.
    /// </summary>
    public abstract class GestionDates
    {
        /// <summary>
        /// Permet de retourner sous forme d'une chaîne de 2 chiffres le numéro du mois précédent par rapport à la date d'aujourd'hui.
        /// </summary>
        /// <returns>Numéro du mois précédent.</returns>
        public static string GetMoisPrecedent()
        {
            return UtilitaireMois(DateTime.Today, -1);
        }

        /// <summary>
        /// Permet de retourner sous forme d'une chaîne de 2 chiffres le numéro du mois précédent par rapport à la date passée en paramètre.
        /// </summary>
        /// <param name="uneDate">Date.</param>
        /// <returns>Numéro du mois précédent.</returns>
        public static string GetMoisPrecedent(DateTime uneDate)
        {
            return UtilitaireMois(uneDate, -1);
        }

        /// <summary>
        /// Permet de retourner sous forme d'une chaîne de 2 chiffres le numéro du mois suivant par rapport à la date d'aujourd'hui.
        /// </summary>
        /// <returns>Numéro du mois suivant.</returns>
        public static string GetMoisSuivant()
        {
            return UtilitaireMois(DateTime.Today, 1);
        }

        /// <summary>
        /// Permet de retourner sous forme d'une chaîne de 2 chiffres le numéro du mois suivant par rapport à la date passée en paramètre.
        /// </summary>
        /// <param name="uneDate">Date.</param>
        /// <returns>Numéro du mois suivant.</returns>
        public static string GetMoisSuivant(DateTime uneDate)
        {
            return UtilitaireMois(uneDate, 1);
        }

        /// <summary>
        /// Retourne vrai si le jour actuel se situe entre les deux jours passés en paramètre.
        /// </summary>
        /// <param name="unJour">Premier jour.</param>
        /// <param name="unAutreJour">Second jour.</param>
        /// <returns>Booléen.</returns>
        public static bool Entre(int unJour, int unAutreJour)
        {
            return DateTime.Today.Day >= unJour && DateTime.Today.Day <= unAutreJour;
        }

        /// <summary>
        /// Retourne vrai si le jour de la date passée en paramètre se situe entre les deux jours passés en paramètre.
        /// </summary>
        /// <param name="unJour">Premier jour.</param>
        /// <param name="unAutreJour">Second jour.</param>
        /// <param name="uneDate">Date.</param>
        /// <returns>Booléen.</returns>
        public static bool Entre(int unJour, int unAutreJour, DateTime uneDate)
        {
            return uneDate.Day >= unJour && uneDate.Day <= unAutreJour;
        }

        /// <summary>
        /// Permet de retourner le mois d'une date passée en paramètre après y avoir ajouté le nombre de mois passé en paramètre également.
        /// </summary>
        /// <param name="date">Date.</param>
        /// <param name="value">Nombre de mois à ajouter.</param>
        /// <returns>Mois.</returns>
        private static string UtilitaireMois(DateTime date, int value)
        {
            date = date.AddMonths(value);
            string mois = date.ToString("MM");
            return mois;
        }
    }
}
