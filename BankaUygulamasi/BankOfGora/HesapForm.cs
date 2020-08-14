using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankaUygulamasi
{
    public partial class HesapForm : Form
    {
        Connections connections = new Connections();
        public User userH;
        public Currencys currencys;
        public Account hesap;
        public Payment pym;
        public Kredi kredi;
        public Faiz faiz;
        public Order order;

        public HesapForm()
        {
            InitializeComponent();
        }

        public void HesapForm_Load(object sender, EventArgs e)
        {


            try
            {

                try
                {
                    //------------------------------------ Hesap bilgilerini getir -------------------------------------------------------------
                    NpgsqlConnection conn = new NpgsqlConnection(connections.connstringDB);
                    conn.Open();
                    NpgsqlCommand cmd = new NpgsqlCommand(connections.getSomeRequest("HESAP", userH.HesapId), conn);
                    NpgsqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        Account acc = new Account(Convert.ToInt32(dr[1]), Convert.ToInt32(dr[2]), Convert.ToInt32(dr[3]), Convert.ToInt32(dr[4]), dr[5].ToString(), Convert.ToInt32(dr[6]), Convert.ToDouble(dr[7]));
                        hesap = acc;
                        conn.Close();
                    }
                    conn.Close();
                    //-----------------------------------------------------------------------------------------------------------------------
                }
                catch (Exception msg)
                {

                    throw;
                }

                try
                {
                    //-------------------------------------- Doviz Bilgilerini getir ---------------------------------------------------------
                    NpgsqlConnection conn2 = new NpgsqlConnection(connections.connstringDB);
                    conn2.Open();
                    NpgsqlCommand cmd2 = new NpgsqlCommand(connections.getSomeRequest("DOVIZ", hesap.CurrencyId), conn2);
                    NpgsqlDataReader dr2 = cmd2.ExecuteReader();
                    if (dr2.Read())
                    {
                        currencys = new Currencys(Convert.ToDouble(dr2[1]), Convert.ToDouble(dr2[3]), Convert.ToDouble(dr2[2]), Convert.ToDouble(dr2[4]));
                        conn2.Close();
                    }
                    conn2.Close();
                }
                catch (Exception msg)
                {

                    throw;
                }

                //-----------------------------------------------------------------------------------------------------------------------
                ////----------------------------------------- Odeme Bilgileri getir  ------------------------------------------------------
                //NpgsqlConnection conn3 = new NpgsqlConnection(connections.connstringDB);
                //conn3.Open();
                //NpgsqlCommand cmd3 = new NpgsqlCommand(connections.getSomeRequest("ODEME", hesap.PaymentId), conn3);
                //NpgsqlDataReader dr3 = cmd3.ExecuteReader();
                //if (dr3.Read())
                //{
                //    pym = new Payment(Convert.ToInt32(dr3[1]), Convert.ToInt32(dr3[2]), Convert.ToInt32(dr3[3]), Convert.ToInt32(dr3[4]));
                //    conn3.Close();
                //}
                //conn3.Close();
                //-----------------------------------------------------------------------------------------------------------------------

                //  -----------------------------------------Kredi Bilgileri getir  ------------------------------------------------------
                NpgsqlConnection conn4 = new NpgsqlConnection(connections.connstringDB);
                conn4.Open();
                NpgsqlCommand cmd4 = new NpgsqlCommand(connections.getSomeRequest("KREDI", 1), conn4);
                NpgsqlDataReader dr4 = cmd4.ExecuteReader();
                if (dr4.Read())
                {
                    kredi = new Kredi(Convert.ToInt32(dr4[2]), Convert.ToInt32(dr4[3]), dr4[4].ToString(), Convert.ToDouble(dr4[5]));
                    conn4.Close();
                }
                conn4.Close();
                // -----------------------------------------------------------------------------------------------------------------------

                try
                {
                    //----------------------------------------- Faiz Bilgileri getir  ------------------------------------------------------
                    NpgsqlConnection conn5 = new NpgsqlConnection(connections.connstringDB);
                    conn5.Open();
                    NpgsqlCommand cmd5 = new NpgsqlCommand(connections.getSomeRequest("FAIZ", hesap.faizId), conn5);
                    NpgsqlDataReader dr5 = cmd5.ExecuteReader();
                    if (dr5.Read())
                    {
                        faiz = new Faiz(Convert.ToDouble(dr5[1]), Convert.ToInt32(dr5[2]));
                        conn5.Close();
                    }
                    conn5.Close();
                    //-----------------------------------------------------------------------------------------------------------------------
                }
                catch (Exception msg)
                {

                    throw;
                }

                //----------------------------------------- Emir Bilgileri getir  ------------------------------------------------------
                //NpgsqlConnection conn6 = new NpgsqlConnection(connections.connstringDB);
                //conn5.Open();
                //NpgsqlCommand cmd6 = new NpgsqlCommand(connections.getSomeRequest("EMIRLER", hesap.faizId), conn6);
                //NpgsqlDataReader dr6 = cmd6.ExecuteReader();
                //if (dr5.Read())
                //{
                //    faiz = new Faiz(Convert.ToDouble(dr5[1]), Convert.ToInt32(dr5[2]), dr5[3].ToString());
                //    conn5.Close();
                //}
                //conn5.Close();
                //-----------------------------------------------------------------------------------------------------------------------

            }
            catch (Exception)
            {

                throw;
            }




            lblHesapTuru.Text = hesap.AT.ATname.Trim();
            lblKullaniciAdi.Text = userH.Name;
            lblKullaniciSoyadi.Text = userH.Lastname;
            lblHesapAdi.Text = hesap.AName;
            lblUserType.Text = userH.userType.Name;
            lblParaTL.Text = hesap.MoneyCount.ToString() + " ₺";
            lblParaEUR.Text = (hesap.MoneyCount * currencys.EURvalue).ToString() + " €";
            lblParaUSD.Text = (hesap.MoneyCount * currencys.USDvalue).ToString() + " $";
            lblParaSTR.Text = (hesap.MoneyCount * currencys.STRvalue).ToString() + " £";
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            PaymentForm pf = new PaymentForm();
            pf.p = pym;
            pf.act = hesap;
            pf.userP = userH;
            pf.Show();
            this.Hide();
        }

        private void BtnKredi_Click(object sender, EventArgs e)
        {
            KrediForm krediForm = new KrediForm();
            krediForm.userK = userH;
            krediForm.hesapK = hesap;
            krediForm.kredi = kredi;
            krediForm.faiz = faiz;
            krediForm.Show();
            this.Hide();
        }

        private void BtnParaGonder_Click(object sender, EventArgs e)
        {
            SendMoney sm = new SendMoney();
            sm.user = userH;
            sm.hesap = hesap;
            sm.Show();
            this.Hide();
        }

        private void BtnBorc_Click(object sender, EventArgs e)
        {
            Borc b = new Borc();
            b.hesap = hesap;
            b.user = userH;
            b.Show();
        }
    }
}
