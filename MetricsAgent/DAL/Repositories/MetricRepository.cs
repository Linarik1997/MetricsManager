using Core.Interfaces;
using MetricsAgent.DAL.Interfaces;
using MetricsAgent.Models;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsAgent.DAL.Repositories
{
    public abstract class MetricRepository<T> : IRepository<T> where T: Models.T,new()
    {
        private const string _connectionString = "Data Source=metrics.db;Version=3;Pooling=true;Max Pool Size=100;";
        public virtual void Create(T item)
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                using (var cmd = new SQLiteCommand(connection))
                {
                    cmd.CommandText = "INSERT INTO cpumetrics(value, time) VALUES(@value,@time);";
                    cmd.Parameters.AddWithValue("@value", item.Value);
                    cmd.Parameters.AddWithValue("@time", item.Dt.TotalSeconds);
                    cmd.Prepare();
                    cmd.ExecuteNonQuery();
                }                    
            }
        }

        public virtual void Delete(T item)
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                using (var cmd = new SQLiteCommand(connection))
                {
                    cmd.CommandText = "DELETE FROM cpumetrics WHERE id = @id;";
                    cmd.Parameters.AddWithValue("@id", item.Id);
                    cmd.Parameters.AddWithValue("@value", item.Value);
                    cmd.Parameters.AddWithValue("@time", item.Dt.TotalSeconds);
                    cmd.Prepare();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public virtual IList<T> GetAll()
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                using (var cmd = new SQLiteCommand(connection))
                {
                    cmd.CommandText = "SELECT * FROM cpumetrics;";
                    var returnList = new List<T>();
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            returnList.Add(new T {
                                Id = reader.GetInt32(0),
                                Value = reader.GetDouble(1),
                                Dt = TimeSpan.FromSeconds(reader.GetInt32(2))});
                        }
                    }
                    return returnList;
                }
            }
        }

        public virtual T GetById(int id)
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                using (var cmd = new SQLiteCommand(connection.ToString()))
                {
                    cmd.CommandText = "SELECT FROM cpumetrics where id = @id;";
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new T
                            {
                                Id = reader.GetInt32(0),
                                Value = reader.GetDouble(1),
                                Dt = TimeSpan.FromSeconds(reader.GetInt32(2))
                            };
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
            }
        }

        public virtual IList<T> GetInPeriod(TimeSpan from, TimeSpan to)
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                using (var cmd = new SQLiteCommand(connection.ToString()))
                {
                    cmd.CommandText = "SELECT * FROM cpumetrics WHERE time BETWEEN @from AND @to;";
                    var returnList = new List<T>();
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            returnList.Add(new T
                            {
                                Id = reader.GetInt32(0),
                                Value = reader.GetDouble(1),
                                Dt = TimeSpan.FromSeconds(reader.GetInt32(2))
                            });
                        }
                    }
                    return returnList;
                }
            }
        }

        public virtual void Update(T item)
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                using (var cmd = new SQLiteCommand(connection))
                {
                    cmd.CommandText = "UPDATE cpumetrics SET value = @value, time = @time WHERE id = @id;";
                    cmd.Parameters.AddWithValue("@id", item.Id);
                    cmd.Parameters.AddWithValue("@value", item.Value);
                    cmd.Parameters.AddWithValue("@time", item.Dt.TotalSeconds);
                    cmd.Prepare();
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
