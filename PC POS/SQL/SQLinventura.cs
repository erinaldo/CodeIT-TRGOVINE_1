﻿using Npgsql;
using System;
using System.Data;
using System.Data.SqlServerCe;

namespace PCPOS.SQL
{
    internal class SQLinventura
    {
        public static string InsertStavke(DataTable DT)
        {
            if (classSQL.remoteConnectionString == "")
            {
                if (classSQL.connection.State.ToString() == "Closed") { classSQL.connection.Open(); }
                SqlCeCommand nonqueryCommand = classSQL.connection.CreateCommand();
                try
                {
                    nonqueryCommand.CommandText = "INSERT INTO inventura_stavke (broj_inventure,sifra_robe,jmj,kolicina,cijena,naziv,porez)" +
                    " VALUES (@broj_inventure,@sifra_robe,@jmj,@kolicina,@cijena,@naziv,@porez)";
                    nonqueryCommand.Parameters.Add("@broj_inventure", SqlDbType.NVarChar, 15);
                    nonqueryCommand.Parameters.Add("@sifra_robe", SqlDbType.NVarChar, 20);
                    nonqueryCommand.Parameters.Add("@jmj", SqlDbType.NVarChar, 15);
                    nonqueryCommand.Parameters.Add("@kolicina", SqlDbType.NVarChar, 10);
                    nonqueryCommand.Parameters.Add("@cijena", SqlDbType.Money, 8);
                    nonqueryCommand.Parameters.Add("@naziv", SqlDbType.NVarChar, 5);
                    nonqueryCommand.Parameters.Add("@porez", SqlDbType.NVarChar, 5);
                    nonqueryCommand.Prepare();

                    for (int i = 0; i < DT.Rows.Count; i++)
                    {
                        nonqueryCommand.Parameters["@broj_inventure"].Value = DT.Rows[i]["broj_inventure"].ToString();
                        nonqueryCommand.Parameters["@sifra_robe"].Value = DT.Rows[i]["sifra_robe"].ToString();
                        nonqueryCommand.Parameters["@jmj"].Value = DT.Rows[i]["jmj"].ToString();
                        nonqueryCommand.Parameters["@kolicina"].Value = DT.Rows[i]["kolicina"].ToString();
                        nonqueryCommand.Parameters["@cijena"].Value = Convert.ToDecimal(DT.Rows[i]["cijena"].ToString());
                        nonqueryCommand.Parameters["@naziv"].Value = DT.Rows[i]["naziv"].ToString();
                        nonqueryCommand.Parameters["@porez"].Value = DT.Rows[i]["porez"].ToString();
                        nonqueryCommand.ExecuteNonQuery();
                    }
                }
                catch (SqlCeException ex)
                {
                    classSQL.connection.Close();
                    return ex.ToString();
                }
                finally
                {
                    classSQL.connection.Close();
                }
                return "";
            }
            else
            {
                if (classSQL.remoteConnection.State.ToString() == "Closed") { classSQL.remoteConnection.Open(); }
                NpgsqlCommand nonqueryCommand = classSQL.remoteConnection.CreateCommand();
                try
                {
                    for (int i = 0; i < DT.Rows.Count; i++)
                    {
                        string sql = "INSERT INTO inventura_stavke (broj_inventure,sifra_robe,jmj,kolicina,cijena,naziv,porez,nbc)" +
                        " VALUES (" +
                        "'" + DT.Rows[i]["broj_inventure"].ToString() + "'," +
                        "'" + DT.Rows[i]["sifra_robe"].ToString() + "'," +
                        "'" + DT.Rows[i]["jmj"].ToString() + "'," +
                        "'" + DT.Rows[i]["kolicina"].ToString() + "'," +
                        "'" + DT.Rows[i]["cijena"].ToString().Replace(",", ".") + "'," +
                        "'" + DT.Rows[i]["naziv"].ToString().Replace("'", "").Replace("\"", "") + "'," +
                        "'" + DT.Rows[i]["porez"].ToString() + "'," +
                        "'" + DT.Rows[i]["nbc"].ToString().Replace(",", ".") + "'" +
                        ")";

                        NpgsqlCommand comm = new NpgsqlCommand(sql, classSQL.remoteConnection);
                        comm.ExecuteNonQuery();
                    }
                }
                catch (SqlCeException ex)
                {
                    classSQL.connection.Close();
                    return ex.ToString();
                }
                finally
                {
                    classSQL.connection.Close();
                }
                return "";
            }
        }

        public static string UpdateStavke(DataTable DT)
        {
            if (classSQL.remoteConnectionString == "")
            {
                if (classSQL.connection.State.ToString() == "Closed") { classSQL.connection.Open(); }

                SqlCeCommand nonqueryCommand = classSQL.connection.CreateCommand();

                try
                {
                    nonqueryCommand.CommandText = "UPDATE inventura_stavke SET broj_inventure=@broj_inventure,sifra_robe=@sifra_robe,jmj=@jmj,kolicina=@kolicina,cijena=@cijena,naziv=@naziv,porez=@porez WHERE broj_inventure=@broj_inventure AND sifra_robe=@sifra_robe";

                    nonqueryCommand.Parameters.Add("@broj_inventure", SqlDbType.NVarChar, 15);
                    nonqueryCommand.Parameters.Add("@sifra_robe", SqlDbType.NVarChar, 20);
                    nonqueryCommand.Parameters.Add("@jmj", SqlDbType.NVarChar, 15);
                    nonqueryCommand.Parameters.Add("@kolicina", SqlDbType.NVarChar, 10);
                    nonqueryCommand.Parameters.Add("@cijena", SqlDbType.Money, 8);
                    nonqueryCommand.Parameters.Add("@naziv", SqlDbType.NVarChar, 5);
                    nonqueryCommand.Parameters.Add("@porez", SqlDbType.NVarChar, 5);

                    nonqueryCommand.Prepare();

                    for (int i = 0; i < DT.Rows.Count; i++)
                    {
                        nonqueryCommand.Parameters["@broj_inventure"].Value = DT.Rows[i]["broj_inventure"].ToString();
                        nonqueryCommand.Parameters["@sifra_robe"].Value = DT.Rows[i]["sifra_robe"].ToString();
                        nonqueryCommand.Parameters["@jmj"].Value = DT.Rows[i]["jmj"].ToString();
                        nonqueryCommand.Parameters["@kolicina"].Value = DT.Rows[i]["kolicina"].ToString();
                        nonqueryCommand.Parameters["@cijena"].Value = Convert.ToDecimal(DT.Rows[i]["cijena"].ToString());
                        nonqueryCommand.Parameters["@naziv"].Value = DT.Rows[i]["naziv"].ToString();
                        nonqueryCommand.Parameters["@porez"].Value = DT.Rows[i]["porez"].ToString();

                        nonqueryCommand.ExecuteNonQuery();
                    }
                }
                catch (SqlCeException ex)
                {
                    classSQL.connection.Close();
                    return ex.ToString();
                }
                finally
                {
                    classSQL.connection.Close();
                }
                return "";
            }
            else
            {
                if (classSQL.remoteConnection.State.ToString() == "Closed") { classSQL.remoteConnection.Open(); }

                NpgsqlCommand nonqueryCommand = classSQL.remoteConnection.CreateCommand();

                try
                {
                    for (int i = 0; i < DT.Rows.Count; i++)
                    {
                        string sql = "UPDATE inventura_stavke SET " +
                        " broj_inventure='" + DT.Rows[i]["broj_inventure"].ToString() + "', " +
                        " sifra_robe='" + DT.Rows[i]["sifra_robe"].ToString() + "'," +
                        " jmj='" + DT.Rows[i]["jmj"].ToString() + "', " +
                        " kolicina='" + DT.Rows[i]["kolicina"].ToString() + "', " +
                        " cijena='" + DT.Rows[i]["cijena"].ToString().Replace(",", ".") + "', " +
                        " naziv='" + DT.Rows[i]["naziv"].ToString() + "', " +
                        " porez='" + DT.Rows[i]["porez"].ToString() + "'  " +
                        " WHERE broj_inventure='" + DT.Rows[i]["broj_inventure"].ToString() + "' AND sifra_robe='" + DT.Rows[i]["sifra_robe"].ToString() + "'";

                        NpgsqlCommand comm = new NpgsqlCommand(sql, classSQL.remoteConnection);
                        comm.ExecuteNonQuery();
                    }
                }
                catch (SqlCeException ex)
                {
                    classSQL.remoteConnection.Close();
                    return ex.ToString();
                }
                finally
                {
                    classSQL.remoteConnection.Close();
                }
                return "";
            }
        }
    }
}