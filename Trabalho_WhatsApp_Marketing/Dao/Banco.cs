using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trabalho_WhatsApp_Marketing.Model;

namespace Trabalho_WhatsApp_Marketing.Dao
{
    class Banco
    {
        protected static SQLiteConnection conexao { get; } = new SQLiteConnection("Data Source = Banco.db");
        public static void AbrirConexao()
        {
            if (conexao.State == ConnectionState.Closed)
            {
                conexao.Open();
            }
        }
        public class Tb_contato
        {
            /// <summary>
            /// Retorna Todos os registros da Tabela
            /// </summary>
            /// <returns></returns>
            public static List<Tb_contato_Model> RetornoCompleto()
            {
                if (conexao.State == ConnectionState.Closed)
                {
                    conexao.Open();
                }
                SQLiteCommand cmd = new SQLiteCommand("select * from tb_contato order by id asc", conexao);
                SQLiteDataAdapter sQLiteDataAdapter = new SQLiteDataAdapter(cmd);
                DataTable dtLista = new DataTable();
                sQLiteDataAdapter.Fill(dtLista);
                List<Tb_contato_Model> ltFinal = new List<Tb_contato_Model>();
                foreach (DataRow dataRow in dtLista.Rows)
                {
                    Tb_contato_Model newTb_Contatos_Model = new Tb_contato_Model();
                    newTb_Contatos_Model.id = Convert.ToInt32(dataRow["id"]);
                    newTb_Contatos_Model.telefone = Convert.ToString(dataRow["telefone"]);
                    newTb_Contatos_Model.uf = Convert.ToString(dataRow["uf"]);
                    newTb_Contatos_Model.municipio = Convert.ToString(dataRow["municipio"]);
                    newTb_Contatos_Model.bairro = Convert.ToString(dataRow["bairro"]);
                    newTb_Contatos_Model.habilitado = Convert.ToInt32(dataRow["habilitado"]);
                    ltFinal.Add(newTb_Contatos_Model);
                }
                return ltFinal;
            }
            
            /// <summary>
            /// Retorna Um registro da Tabela
            /// </summary>
            /// <returns></returns>
            public static Tb_contato_Model Retorno(int idLocal)
            {
                Tb_contato_Model tb_ContatosFinal = new Tb_contato_Model();

                if (conexao.State == ConnectionState.Closed)
                {
                    conexao.Open();
                }
                object a = tb_ContatosFinal;

                SQLiteCommand cmd = new SQLiteCommand("select * from tb_contato where id = @id", conexao);
                cmd.Parameters.AddWithValue("id", idLocal);
                SQLiteDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    if (Convert.ToInt32(dr["id"]) == idLocal)
                    {
                        tb_ContatosFinal.id = Convert.ToInt32(dr["id"]);
                        tb_ContatosFinal.telefone = Convert.ToString(dr["telefone"]);
                        tb_ContatosFinal.uf = Convert.ToString(dr["uf"]);
                        tb_ContatosFinal.municipio = Convert.ToString(dr["municipio"]);
                        tb_ContatosFinal.bairro = Convert.ToString(dr["bairro"]);
                        tb_ContatosFinal.habilitado = Convert.ToInt32(dr["habilitado"]);
                        break;
                    }
                }
                return tb_ContatosFinal;

            }

            /// <summary>
            /// Retorna Um registro da Tabela
            /// </summary>
            /// <param name="telefoneLocal"></param>
            /// <returns></returns>
            public static Tb_contato_Model Retorno(string telefoneLocal)
            {
                Tb_contato_Model tb_ContatosFinal = new Tb_contato_Model();

                if (conexao.State == ConnectionState.Closed)
                {
                    conexao.Open();
                }
                object a = tb_ContatosFinal;

                SQLiteCommand cmd = new SQLiteCommand("select * from tb_contato where telefone = @telefone", conexao);
                cmd.Parameters.AddWithValue("telefone", telefoneLocal);
                SQLiteDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    if (Convert.ToString(dr["telefone"]).Equals(telefoneLocal))
                    {
                        tb_ContatosFinal.id = Convert.ToInt32(dr["id"]);
                        tb_ContatosFinal.telefone = Convert.ToString(dr["telefone"]);
                        tb_ContatosFinal.uf = Convert.ToString(dr["uf"]);
                        tb_ContatosFinal.municipio = Convert.ToString(dr["municipio"]);
                        tb_ContatosFinal.bairro = Convert.ToString(dr["bairro"]);
                        tb_ContatosFinal.habilitado = Convert.ToInt32(dr["habilitado"]);
                        break;
                    }
                }
                return tb_ContatosFinal;

            }

            /// <summary>
            /// Insere registros na tabela
            /// </summary>
            /// <param name="tb_Contatos_Model"></param>
            public static void Inserir(Tb_contato_Model tb_Contatos_Model)
            {
                if (conexao.State == ConnectionState.Closed)
                {
                    conexao.Open();
                }
                SQLiteCommand cmd = new SQLiteCommand("insert into tb_contato (telefone, uf, municipio, bairro, habilitado) values (@telefone, @uf, @municipio, @bairro, @habilitado)", conexao);
                cmd.Parameters.AddWithValue("telefone", tb_Contatos_Model.telefone);
                cmd.Parameters.AddWithValue("uf", tb_Contatos_Model.uf);
                cmd.Parameters.AddWithValue("municipio", tb_Contatos_Model.municipio);
                cmd.Parameters.AddWithValue("bairro", tb_Contatos_Model.bairro);
                cmd.Parameters.AddWithValue("habilitado", tb_Contatos_Model.habilitado);
                cmd.ExecuteNonQuery();
            }
            
            /// <summary>
            /// Atualiza registros na tabela
            /// </summary>
            /// <param name="tb_Contatos_Model"></param>
            public static void Atualizar(Tb_contato_Model tb_Contatos_Model)
            {
                if (conexao.State == ConnectionState.Closed)
                {
                    conexao.Open();
                }

                SQLiteCommand cmd = new SQLiteCommand("update tb_contato set telefone = @telefone, uf = @uf, municipio = @municipio, bairro = @bairro, habilitado = @habilitado where id = @id", conexao);
                cmd.Parameters.AddWithValue("id", tb_Contatos_Model.id);
                cmd.Parameters.AddWithValue("telefone", tb_Contatos_Model.telefone);
                cmd.Parameters.AddWithValue("uf", tb_Contatos_Model.uf);
                cmd.Parameters.AddWithValue("municipio", tb_Contatos_Model.municipio);
                cmd.Parameters.AddWithValue("bairro", tb_Contatos_Model.bairro);
                cmd.Parameters.AddWithValue("habilitado", tb_Contatos_Model.habilitado);
                cmd.ExecuteNonQuery();
            }

            /// <summary>
            /// Deleta registros na tabela
            /// </summary>
            /// <param name="tb_Contatos_Model"></param>
            public static void Deletar(Tb_contato_Model tb_Contatos_Model)
            {
                if (conexao.State == ConnectionState.Closed)
                {
                    conexao.Open();
                }
                SQLiteCommand cmd = new SQLiteCommand("delete from tb_contato where id = @id", conexao);
                cmd.Parameters.AddWithValue("id", tb_Contatos_Model.id);
                cmd.ExecuteNonQuery();
            }

            /// <summary>
            /// Apaga Todos os Registros da Tabela... Muito Cuidado ao utilizar esta Função
            /// </summary>
            public static void Truncate()
            {
                if (conexao.State == ConnectionState.Closed)
                {
                    conexao.Open();
                }
                SQLiteCommand cmd = new SQLiteCommand("delete from tb_contato", conexao);
                cmd.ExecuteNonQuery();
                cmd.CommandText = "delete from sqlite_sequence where name='tb_contato'";
                cmd.ExecuteNonQuery();
            }
        }
        public class Tb_contato_email
        {
            /// <summary>
            /// Retorna Todos os registros da Tabela
            /// </summary>
            /// <returns></returns>
            public static List<Tb_contato_email_Model> RetornoCompleto()
            {

                if (conexao.State == ConnectionState.Closed)
                {
                    conexao.Open();
                }
                SQLiteCommand cmd = new SQLiteCommand("select * from tb_contato_email order by id asc", conexao);
                SQLiteDataAdapter sQLiteDataAdapter = new SQLiteDataAdapter(cmd);
                DataTable dtLista = new DataTable();
                sQLiteDataAdapter.Fill(dtLista);
                List<Tb_contato_email_Model> ltFinal = new List<Tb_contato_email_Model>();
                foreach (DataRow dataRow in dtLista.Rows)
                {
                    Tb_contato_email_Model newTb_contato_email_Model = new Tb_contato_email_Model();
                    newTb_contato_email_Model.id = Convert.ToInt32(dataRow["id"]);
                    newTb_contato_email_Model.telefone = Convert.ToString(dataRow["telefone"]);
                    newTb_contato_email_Model.emulador = Convert.ToString(dataRow["emulador"]);
                    newTb_contato_email_Model.whatsapp = Convert.ToInt32(dataRow["whatsapp"]);
                    newTb_contato_email_Model.business = Convert.ToInt32(dataRow["business"]);
                    newTb_contato_email_Model.habilitado = Convert.ToInt32(dataRow["habilitado"]);
                    ltFinal.Add(newTb_contato_email_Model);
                }
                return ltFinal;
            }
            /// <summary>
            /// Retorna Todos os registros para envio  da Tabela
            /// </summary>
            /// <returns></returns>
            public static List<Tb_contato_email_Model> RetornoCompletoParaEnvio()
            {

                if (conexao.State == ConnectionState.Closed)
                {
                    conexao.Open();
                }
                SQLiteCommand cmd = new SQLiteCommand("SELECT * from tb_contato_email WHERE whatsapp = 0 AND business = 0 AND habilitado = 1  order by id asc", conexao);
                SQLiteDataAdapter sQLiteDataAdapter = new SQLiteDataAdapter(cmd);
                DataTable dtLista = new DataTable();
                sQLiteDataAdapter.Fill(dtLista);
                List<Tb_contato_email_Model> ltFinal = new List<Tb_contato_email_Model>();
                foreach (DataRow dataRow in dtLista.Rows)
                {
                    Tb_contato_email_Model newTb_contato_email_Model = new Tb_contato_email_Model();
                    newTb_contato_email_Model.id = Convert.ToInt32(dataRow["id"]);
                    newTb_contato_email_Model.telefone = Convert.ToString(dataRow["telefone"]);
                    newTb_contato_email_Model.emulador = Convert.ToString(dataRow["emulador"]);
                    newTb_contato_email_Model.whatsapp = Convert.ToInt32(dataRow["whatsapp"]);
                    newTb_contato_email_Model.business = Convert.ToInt32(dataRow["business"]);
                    newTb_contato_email_Model.habilitado = Convert.ToInt32(dataRow["habilitado"]);
                    ltFinal.Add(newTb_contato_email_Model);
                }
                return ltFinal;
            }

            /// <summary>
            /// Retorna Um registro da Tabela
            /// </summary>
            /// <returns></returns>
            public static Tb_contato_email_Model Retorno(int idLocal)
            {
                Tb_contato_email_Model tb_contato_email_Model_Final = new Tb_contato_email_Model();
                if (conexao.State == ConnectionState.Closed)
                {
                    conexao.Open();
                }

                SQLiteCommand cmd = new SQLiteCommand("select * from tb_contato_email where id = @id", conexao);
                cmd.Parameters.AddWithValue("id", idLocal);
                SQLiteDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    if (Convert.ToInt32(dr["id"]) == idLocal)
                    {
                        tb_contato_email_Model_Final.id = Convert.ToInt32(dr["id"]);
                        tb_contato_email_Model_Final.telefone = Convert.ToString(dr["telefone"]);
                        tb_contato_email_Model_Final.emulador = Convert.ToString(dr["emulador"]);
                        tb_contato_email_Model_Final.whatsapp = Convert.ToInt32(dr["whatsapp"]);
                        tb_contato_email_Model_Final.business = Convert.ToInt32(dr["business"]);
                        tb_contato_email_Model_Final.habilitado = Convert.ToInt32(dr["habilitado"]);
                        break;
                    }
                }
                return tb_contato_email_Model_Final;
            }

            /// <summary>
            /// Insere registros na tabela
            /// </summary>
            /// <param name="tb_Contatos_Enviados_Model"></param>
            public static void Inserir(Tb_contato_email_Model tb_contato_email_Model)
            {
                if (conexao.State == ConnectionState.Closed)
                {
                    conexao.Open();
                }
                SQLiteCommand cmd = new SQLiteCommand("insert into tb_contato_email (telefone, emulador, whatsapp, business, habilitado) values (@telefone, @emulador, @whatsapp, @business, @habilitado)", conexao);
                cmd.Parameters.AddWithValue("telefone", tb_contato_email_Model.telefone);
                cmd.Parameters.AddWithValue("emulador", tb_contato_email_Model.emulador);
                cmd.Parameters.AddWithValue("whatsapp", tb_contato_email_Model.whatsapp);
                cmd.Parameters.AddWithValue("business", tb_contato_email_Model.business);
                cmd.Parameters.AddWithValue("habilitado", tb_contato_email_Model.habilitado);
                cmd.ExecuteNonQuery();
            }

            /// <summary>
            /// Atualiza registros na tabela
            /// </summary>
            /// <param name="tb_Contatos_Model"></param>
            public static void Atualizar(Tb_contato_email_Model tb_contato_email_Model)
            {
                if (conexao.State == ConnectionState.Closed)
                {
                    conexao.Open();
                }
                SQLiteCommand cmd = new SQLiteCommand("update tb_contato_email set telefone = @telefone, emulador = @emulador, whatsapp = @whatsapp, business = @business, habilitado = @habilitado where id = @id", conexao);
                cmd.Parameters.AddWithValue("id", tb_contato_email_Model.id);
                cmd.Parameters.AddWithValue("telefone", tb_contato_email_Model.telefone);
                cmd.Parameters.AddWithValue("emulador", tb_contato_email_Model.emulador);
                cmd.Parameters.AddWithValue("whatsapp", tb_contato_email_Model.whatsapp);
                cmd.Parameters.AddWithValue("business", tb_contato_email_Model.business);
                cmd.Parameters.AddWithValue("habilitado", tb_contato_email_Model.habilitado);
                cmd.ExecuteNonQuery();
            }

            /// <summary>
            /// Resetar registros na tabela
            /// </summary>
            public static void Resetar()
            {
                if (conexao.State == ConnectionState.Closed)
                {
                    conexao.Open();
                }
                SQLiteCommand cmd = new SQLiteCommand("update tb_contato_email set emulador = '', whatsapp = 0, business = 0", conexao);
                cmd.ExecuteNonQuery();
            }

            /// <summary>
            /// Deleta registros na tabela
            /// </summary>
            /// <param name="tb_Contatos_Model"></param>
            public static void Deletar(Tb_contato_email_Model tb_contato_email_Model)
            {
                if (conexao.State == ConnectionState.Closed)
                {
                    conexao.Open();
                }
                SQLiteCommand cmd = new SQLiteCommand("delete from tb_contato_email where id = @id", conexao);
                cmd.Parameters.AddWithValue("id", tb_contato_email_Model.id);
                cmd.ExecuteNonQuery();
            }

            /// <summary>
            /// Apaga Todos os Registros da Tabela... Muito Cuidado ao utilizar esta Função
            /// </summary>
            public static void Truncate()
            {
                if (conexao.State == ConnectionState.Closed)
                {
                    conexao.Open();
                }
                SQLiteCommand cmd = new SQLiteCommand("delete from tb_contato_email", conexao);
                cmd.ExecuteNonQuery();
                cmd.CommandText = "delete from sqlite_sequence where name='tb_contato_email'";
                cmd.ExecuteNonQuery();
            }
        }
        public class Tb_emulador
        {
            /// <summary>
            /// Retorna Todos os registros da Tabela
            /// </summary>
            /// <returns></returns>
            public static List<Tb_emulador_Model> RetornoCompleto()
            {
                if (conexao.State == ConnectionState.Closed)
                {
                    conexao.Open();
                }
                SQLiteCommand cmd = new SQLiteCommand("select * from tb_emulador order by id asc", conexao);
                SQLiteDataAdapter sQLiteDataAdapter = new SQLiteDataAdapter(cmd);
                DataTable dtLista = new DataTable();
                sQLiteDataAdapter.Fill(dtLista);
                List<Tb_emulador_Model> ltFinal = new List<Tb_emulador_Model>();
                foreach (DataRow dataRow in dtLista.Rows)
                {
                    Tb_emulador_Model newTb_emulador_Model = new Tb_emulador_Model();
                    newTb_emulador_Model.id = Convert.ToInt32(dataRow["id"]);
                    newTb_emulador_Model.udid = Convert.ToString(dataRow["udid"]);
                    newTb_emulador_Model.nome = Convert.ToString(dataRow["nome"]);
                    newTb_emulador_Model.numero_whatsapp = Convert.ToString(dataRow["numero_whatsapp"]);
                    newTb_emulador_Model.numero_whatsapp_business = Convert.ToString(dataRow["numero_whatsapp_business"]);
                    newTb_emulador_Model.habilitado = Convert.ToInt32(dataRow["habilitado"]);

                    ltFinal.Add(newTb_emulador_Model);
                }
                return ltFinal;
            }


            /// <summary>
            /// Retorna Todos os registros da Tabela
            /// </summary>
            /// <returns></returns>
            public static List<Tb_emulador_Model> RetornoCompletoHabilitado()
            {
                if (conexao.State == ConnectionState.Closed)
                {
                    conexao.Open();
                }
                SQLiteCommand cmd = new SQLiteCommand("select * from tb_emulador where habilitado = '1' order by id asc", conexao);
                SQLiteDataAdapter sQLiteDataAdapter = new SQLiteDataAdapter(cmd);
                DataTable dtLista = new DataTable();
                sQLiteDataAdapter.Fill(dtLista);
                List<Tb_emulador_Model> ltFinal = new List<Tb_emulador_Model>();
                foreach (DataRow dataRow in dtLista.Rows)
                {
                    Tb_emulador_Model newTb_emulador_Model = new Tb_emulador_Model();
                    newTb_emulador_Model.id = Convert.ToInt32(dataRow["id"]);
                    newTb_emulador_Model.udid = Convert.ToString(dataRow["udid"]);
                    newTb_emulador_Model.nome = Convert.ToString(dataRow["nome"]);
                    newTb_emulador_Model.numero_whatsapp = Convert.ToString(dataRow["numero_whatsapp"]);
                    newTb_emulador_Model.numero_whatsapp_business = Convert.ToString(dataRow["numero_whatsapp_business"]);
                    newTb_emulador_Model.habilitado = Convert.ToInt32(dataRow["habilitado"]);

                    ltFinal.Add(newTb_emulador_Model);
                }
                return ltFinal;
            }


            /// <summary>
            /// Retorna Um registro da Tabela
            /// </summary>
            /// <returns></returns>
            public static Tb_emulador_Model Retorno(int idLocal)
            {
                Tb_emulador_Model tb_emulador_Model_Final = new Tb_emulador_Model();
                if (conexao.State == ConnectionState.Closed)
                {
                    conexao.Open();
                }

                SQLiteCommand cmd = new SQLiteCommand("select * from tb_emulador where id = @id", conexao);
                cmd.Parameters.AddWithValue("id", idLocal);
                SQLiteDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    if (Convert.ToInt32(dr["id"]) == idLocal)
                    {
                        tb_emulador_Model_Final.id = Convert.ToInt32(dr["id"]);
                        tb_emulador_Model_Final.udid = Convert.ToString(dr["udid"]);
                        tb_emulador_Model_Final.nome = Convert.ToString(dr["nome"]);
                        tb_emulador_Model_Final.numero_whatsapp = Convert.ToString(dr["numero_whatsapp"]);
                        tb_emulador_Model_Final.numero_whatsapp_business = Convert.ToString(dr["numero_whatsapp_business"]);
                        tb_emulador_Model_Final.habilitado = Convert.ToInt32(dr["habilitado"]);
                        break;
                    }
                }
                return tb_emulador_Model_Final;
            }


            /// <summary>
            /// Insere registros na tabela
            /// </summary>
            /// <param name="tb_emulador_Model"></param>
            public static void Inserir(Tb_emulador_Model tb_emulador_Model)
            {
                if (conexao.State == ConnectionState.Closed)
                {
                    conexao.Open();
                }
                SQLiteCommand cmd = new SQLiteCommand("insert into tb_emulador (udid, nome, numero_whatsapp, numero_whatsapp_business, habilitado) values (@udid, @nome, @numero_whatsapp, @numero_whatsapp_business, @habilitado)", conexao);
                cmd.Parameters.AddWithValue("udid", tb_emulador_Model.udid);
                cmd.Parameters.AddWithValue("nome", tb_emulador_Model.nome);
                cmd.Parameters.AddWithValue("numero_whatsapp", tb_emulador_Model.numero_whatsapp);
                cmd.Parameters.AddWithValue("numero_whatsapp_business", tb_emulador_Model.numero_whatsapp_business);
                cmd.Parameters.AddWithValue("habilitado", tb_emulador_Model.habilitado);
                cmd.ExecuteNonQuery();
            }


            /// <summary>
            /// Atualiza registros na tabela
            /// </summary>
            /// <param name="tb_emulador_Model"></param>
            public static void Atualizar(Tb_emulador_Model tb_emulador_Model)
            {
                if (conexao.State == ConnectionState.Closed)
                {
                    conexao.Open();
                }
                SQLiteCommand cmd = new SQLiteCommand("update tb_emulador set udid = @udid, nome = @nome, numero_whatsapp = @numero_whatsapp, numero_whatsapp_business=@numero_whatsapp_business, habilitado = @habilitado where id = @id", conexao);
                cmd.Parameters.AddWithValue("id", tb_emulador_Model.id);
                cmd.Parameters.AddWithValue("udid", tb_emulador_Model.udid);
                cmd.Parameters.AddWithValue("nome", tb_emulador_Model.nome);
                cmd.Parameters.AddWithValue("numero_whatsapp", tb_emulador_Model.numero_whatsapp);
                cmd.Parameters.AddWithValue("numero_whatsapp_business", tb_emulador_Model.numero_whatsapp_business);
                cmd.Parameters.AddWithValue("habilitado", tb_emulador_Model.habilitado);

                cmd.ExecuteNonQuery();
            }


            /// <summary>
            /// Deleta registros na tabela
            /// </summary>
            /// <param name="tb_emulador_Model"></param>
            public static void Deletar(Tb_emulador_Model tb_emulador_Model)
            {
                if (conexao.State == ConnectionState.Closed)
                {
                    conexao.Open();
                }
                SQLiteCommand cmd = new SQLiteCommand("delete from tb_emulador where id = @id", conexao);
                cmd.Parameters.AddWithValue("id", tb_emulador_Model.id);
                cmd.ExecuteNonQuery();
            }


            /// <summary>
            /// Apaga Todos os Registros da Tabela... Muito Cuidado ao utilizar esta Função
            /// </summary>
            public static void Truncate()
            {
                if (conexao.State == ConnectionState.Closed)
                {
                    conexao.Open();
                }
                SQLiteCommand cmd = new SQLiteCommand("delete from tb_emulador", conexao);
                cmd.ExecuteNonQuery();
                cmd.CommandText = "delete from sqlite_sequence where name='tb_emulador'";
                cmd.ExecuteNonQuery();
            }
        }



        public class Tb_estado
        {
            /// <summary>
            /// Retorna Todos os registros da Tabela
            /// </summary>
            /// <returns></returns>
            public static List<Tb_estado_Model> RetornoCompleto()
            {
                if (conexao.State == ConnectionState.Closed)
                {
                    conexao.Open();
                }
                SQLiteCommand cmd = new SQLiteCommand("select * from tb_estado order by nome asc", conexao);
                SQLiteDataAdapter sQLiteDataAdapter = new SQLiteDataAdapter(cmd);
                DataTable dtLista = new DataTable();
                sQLiteDataAdapter.Fill(dtLista);
                List<Tb_estado_Model> ltFinal = new List<Tb_estado_Model>();
                foreach (DataRow dataRow in dtLista.Rows)
                {
                    Tb_estado_Model newTb_estado_Model = new Tb_estado_Model();
                    newTb_estado_Model.id = Convert.ToInt32(dataRow["id"]);
                    newTb_estado_Model.codigo_uf = Convert.ToString(dataRow["codigo_uf"]);
                    newTb_estado_Model.nome = Convert.ToString(dataRow["nome"]);
                    newTb_estado_Model.uf = Convert.ToString(dataRow["uf"]);
                    newTb_estado_Model.regiao = Convert.ToString(dataRow["regiao"]);


                    ltFinal.Add(newTb_estado_Model);
                }
                return ltFinal;
            }
        }
        public class Tb_municipio
        {
            /// <summary>
            /// Retorna Todos os registros da Tabela
            /// </summary>
            /// <returns></returns>
            public static List<Tb_municipio_Model> RetornoCompleto()
            {
                if (conexao.State == ConnectionState.Closed)
                {
                    conexao.Open();
                }
                SQLiteCommand cmd = new SQLiteCommand("select * from tb_municipio order by nome asc", conexao);
                SQLiteDataAdapter sQLiteDataAdapter = new SQLiteDataAdapter(cmd);
                DataTable dtLista = new DataTable();
                sQLiteDataAdapter.Fill(dtLista);
                List<Tb_municipio_Model> ltFinal = new List<Tb_municipio_Model>();
                foreach (DataRow dataRow in dtLista.Rows)
                {
                    Tb_municipio_Model newTb_municipio_Model = new Tb_municipio_Model();
                    newTb_municipio_Model.id = Convert.ToInt32(dataRow["id"]);
                    newTb_municipio_Model.codigo = Convert.ToString(dataRow["codigo"]);
                    newTb_municipio_Model.nome = Convert.ToString(dataRow["nome"]);
                    newTb_municipio_Model.uf = Convert.ToString(dataRow["uf"]);


                    ltFinal.Add(newTb_municipio_Model);
                }
                return ltFinal;
            }
        }
        public class Tb_bairro
        {
            /// <summary>
            /// Retorna Todos os registros da Tabela
            /// </summary>
            /// <returns></returns>
            public static List<Tb_bairro_Model> RetornoCompleto()
            {
                if (conexao.State == ConnectionState.Closed)
                {
                    conexao.Open();
                }
                SQLiteCommand cmd = new SQLiteCommand("select * from tb_bairro order by nome asc", conexao);
                SQLiteDataAdapter sQLiteDataAdapter = new SQLiteDataAdapter(cmd);
                DataTable dtLista = new DataTable();
                sQLiteDataAdapter.Fill(dtLista);
                List<Tb_bairro_Model> ltFinal = new List<Tb_bairro_Model>();
                foreach (DataRow dataRow in dtLista.Rows)
                {
                    Tb_bairro_Model newTb_bairro_Model = new Tb_bairro_Model();
                    newTb_bairro_Model.id = Convert.ToInt32(dataRow["id"]);
                    newTb_bairro_Model.codigo = Convert.ToString(dataRow["codigo"]);
                    newTb_bairro_Model.nome = Convert.ToString(dataRow["nome"]);
                    newTb_bairro_Model.uf = Convert.ToString(dataRow["uf"]);



                    ltFinal.Add(newTb_bairro_Model);
                }
                return ltFinal;
            }
        }
        
    }
}
