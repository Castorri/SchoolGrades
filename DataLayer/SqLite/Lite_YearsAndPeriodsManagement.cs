﻿using SchoolGrades.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace SchoolGrades
{
    internal partial class SqLite_DataLayer : DataLayer
    {
        internal override void CreateTableSchoolYears()
        {
            using (DbConnection conn = Connect())
            {
                DbCommand cmd = conn.CreateCommand();
                // Tabella: SchoolYears
                cmd.CommandText = @"CREATE TABLE SchoolYears (
                    'idSchoolYear' VARCHAR(4) NOT NULL,
                    'shortDesc' VARCHAR(10) NULL,
                    'notes' VARCHAR(255) NULL,
                    PRIMARY KEY(idSchoolYear));";
                cmd.ExecuteNonQuery();
            }
        }
        internal override bool SchoolYearExists(string idSchoolYear)
        {
            using (DbConnection conn = Connect())
            {
                DbCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT idSchoolYear" +
                    " FROM SchoolYears" +
                    " WHERE idSchoolYear='" + idSchoolYear + "'" + 
                    " LIMIT 1; ";
                var result = cmd.ExecuteScalar();
                return (result != null);
            }
        }
        internal override void AddSchoolYear(SchoolYear newSchoolYear)
        {
            using (DbConnection conn = Connect())
            {
                DbCommand cmd = conn.CreateCommand();
                cmd.CommandText = "INSERT INTO SchoolYears" +
                    " (idSchoolYear,shortDesc,notes)" +
                    " Values (" +
                    SqlString(newSchoolYear.IdSchoolYear) +
                    "," + SqlString(newSchoolYear.ShortDescription) + "" +
                    "," + SqlString(newSchoolYear.Notes) + "" +
                    ");";
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
        }
    }
}
