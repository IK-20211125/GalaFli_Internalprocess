using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows.Forms;

//フォルダを掘ってファイルを整理するような感覚で、名前空間を作ってクラスを整理するものが namespace
namespace test_2
{
    //jsonから受け取ったすべてのデータが入るクラス（構造体）
    public class Data
    {
        public Statedata[] data { get; set; }
    }

    // 画面状態のクラス（構造体）
    public class Statedata
    {
        public string name { get; set; }
        public bool basis { get; set; }
        public Key[] keys { get; set; }
    }

    // Keyのクラス（構造体）
    public class Key
    {
        public string keyname { get; set; }
        public string action { get; set; }
        public string[][] value { get; set; }
        public string text { get; set; }
    }


    internal static class Program
    {
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //使用するForm1クラスのインスタンスを作成
            Form1 form1 = new Form1();

            try
            {
                //ファイルパスの指定(自身で用意した場所のパスを書く)
                string filePath = @"C:\Users\Kodai\source\repos\test_2\test_2\all_data.json";

                //ファイルを読み込み
                string json = File.ReadAllText(filePath);

                //JSONをクラスオブジェクト(インスタンス)に変換
                var jsonDataTemp = JsonSerializer.Deserialize<Data>(json);

                // form1にあるJson_LoadクラスにjsonDataを渡す
                form1.Json_Load(jsonDataTemp);

                // form1を動かす
                Application.Run(form1);
            }

            catch (Exception ex)
            {
                // エラーメッセージ表示やログ出力などのエラーハンドリングを行う
                Debug.WriteLine("JSONファイルの読み込みエラー: " + ex.Message);
            }
        }
    }
}
