// <copyright file="BDD.cs" company="Dylan LE FLOUR">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace GSB_GestionCloture
{
    using System.Configuration;
    using MySql.Data.MySqlClient;

    /// <summary>
    /// Classe d'accès aux données.
    /// </summary>
    public class BDD
    {
        private MySqlConnection cnMySql;

        /// <summary>
        /// Initializes a new instance of the <see cref="BDD"/> class.
        /// Initialise une nouvelle instance de la classe BDD.
        /// </summary>
        public BDD()
        {
            ConnectionStringSettings cnString = ConfigurationManager.ConnectionStrings["StrConnGsb"];
            this.cnMySql = new MySqlConnection(string.Format(
                        cnString.ConnectionString,
                        ConfigurationManager.AppSettings["SERVER"],
                        ConfigurationManager.AppSettings["DATABASE"],
                        ConfigurationManager.AppSettings["UID"],
                        ConfigurationManager.AppSettings["PWD"]));
        }

        /// <summary>
        /// Exécution d'une requête d'Administration passée en paramètre.
        /// </summary>
        /// <param name="query">Requête d'administration.</param>
        /// <param name="value">Valeurs associatives.</param>
        /// <param name="key">Clés associatives.</param>
        public void AdminQuery(string query, string[] value, string[] key)
        {
            this.cnMySql.Open();
            MySqlCommand command = this.cnMySql.CreateCommand();
            command.CommandText = query;
            for (int i = 0; i <= key.Length - 1; i++)
            {
                command.Parameters.AddWithValue(key[i], value[i]);
            }

            command.ExecuteNonQuery();
            this.cnMySql.Close();
        }

        /// <summary>
        /// Exécution d'une requête de type Select passée en paramètre.
        /// </summary>
        /// <param name="query">Requête de type Select.</param>
        /// <returns>Résultats de la requête.</returns>
        public MySqlDataReader SelectQuery(string query)
        {
            this.cnMySql.Open();
            MySqlCommand command = new MySqlCommand(query, this.cnMySql);
            MySqlDataReader dataReader = command.ExecuteReader();
            command.Dispose();
            this.cnMySql.Close();
            return dataReader;
        }
    }
}
