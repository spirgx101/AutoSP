using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParallelSP.DAO
{
    public class DAOGoods
    {
        private string SqlConnection = string.Empty;
        private string SqlCommand = string.Empty;
        private DataTable goods_table = new DataTable();

        public DAOGoods(DAOProc proc)
        {
            SqlConnection = proc.CONN_STR;

            string para_str = proc.PARA.Trim();
            string[] para_list = para_str.Trim().Split(',');

            foreach (string p in para_list)
            {
                if (p.StartsWith("$"))
                {
                    DAOPara dao_para = new DAOPara(p);
                    goods_table = dao_para.GetParameterValueOfDatatable(proc.CONN_STR, dao_para.GetParameterValue());
                }
            }
        }

        public List<string>[] SplitAllGoods(int number_thread = 10)
        {
            List<string>[] goods = new List<string>[number_thread];
            for (int i = 0; i < number_thread; i++) goods[i] = new List<string>();

            int count = (int)(Math.Ceiling(((double)goods_table.Rows.Count) / number_thread));

            int idx = 0;
            foreach(DataRow dr in goods_table.Rows)
            {
                goods[idx/count].Add(dr[0].ToString());
                idx++;
            }

            return goods;
        }
    }
}
