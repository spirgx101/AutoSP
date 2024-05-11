using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParallelSP.DAO;

namespace ParallelSP.Interface
{
    interface IProcedureTypeA
    {
        List<string> CreateProcedureList(DAOProc proc, string run_time);
    }

    interface IProcedureTypeB
    {
        List<string> CreateProcedureList(DAOProc proc, string run_time);
    }

    interface IProcedureTypeN
    {
        List<string> CreateProcedureList(DAOProc proc, string run_time);
    }

    public class ProcedureTypeN:IProcedureTypeN
    {
        public List<string> CreateProcedureList(DAOProc proc, string run_time)
        {
            List<string> commandList = new List<string>();
            ParameterParser parser = new ParameterParser(proc);

            string sqlString = "EXEC " + proc.SP + " " + parser.Get_Proc_Para() + ";" + Environment.NewLine;
            string log_string = run_time + ";000000;999999^";
            commandList.Add(log_string + sqlString);

            return commandList;
        }
    }

    public class ProcedureTypeA1 : IProcedureTypeA
    {
        public List<string> CreateProcedureList(DAOProc proc, string run_time)
        {
            List<string>[] str_list = new DAOSite().SplitAllSites(proc.THREAD);

            List<string> commandList = new List<string>();
            ParameterParser parser = new ParameterParser(proc);

            foreach (List<string> str in str_list)
            {
                string sqlString = string.Empty;
                foreach (string s in str)
                {
                    sqlString += "EXEC " + proc.SP + " " + parser.Parse_Store_No(s) + ";" + Environment.NewLine;
                }
                string log_string = run_time + ";" + str[0] +";" + str[str.Count-1] + "^";
                commandList.Add(log_string + sqlString);
            }

            return commandList;
        }
    }

    public class ProcedureTypeA2 : IProcedureTypeA
    {
        public List<string> CreateProcedureList(DAOProc proc, string run_time)
        {
            List<string>[] str_list = new DAOSite().SplitAllSites(proc.THREAD);

            List<string> commandList = new List<string>();
            ParameterParser parser = new ParameterParser(proc);

            string sqlString = string.Empty;
            foreach (List<string> str in str_list)
            {
                sqlString = "EXEC " + proc.SP + " " + parser.Parse_Store_No(str[0], str[str.Count - 1]) + ";" + Environment.NewLine;
                string log_string = run_time + ";" + str[0] + ";" + str[str.Count - 1] + "^";
                commandList.Add(log_string + sqlString);
            }

            return commandList;
        }
    }

    public class ProcedureTypeB : IProcedureTypeB
    {
        public List<string> CreateProcedureList(DAOProc proc, string run_time)
        {
            List<string>[] goods_list = new DAOGoods(proc).SplitAllGoods(proc.THREAD);

            List<string> commandList = new List<string>();
            ParameterParser parser = new ParameterParser(proc);

            string goods_para = parser.Parse_Goods_Para();

            foreach (List<string> goods in goods_list)
            {
                string sqlString = string.Empty;
                foreach (string s in goods)
                {
                    sqlString += "EXEC " + proc.SP + " " + parser.Parse_Store_No(s).Replace(goods_para, "'" + s + "'")  + ";" + Environment.NewLine;
                }
                string log_string = run_time + ";" + goods[0] + ";" + goods[goods.Count - 1] + "^";
                commandList.Add(log_string + sqlString);
            }

            return commandList;
        }
    }

    public class ParameterParser
    {
        private string PROC_PARAMETER = string.Empty;
        private string PROC_CONNECTION_STR = string.Empty;

        public ParameterParser(DAOProc proc)
        {           
            PROC_PARAMETER = proc.PARA.Trim();
            PROC_CONNECTION_STR = proc.CONN_STR;

            List<string> para = PROC_PARAMETER.Split(',').Select(p => p.Trim()).ToList();

            foreach (string p in para)
            {
                if (p.Trim().StartsWith("#"))
                {
                    DAOPara dao_para = new DAOPara(p);
                    string para_value = dao_para.GetParameterValueOfString(PROC_CONNECTION_STR, dao_para.GetParameterValue());
                    PROC_PARAMETER = PROC_PARAMETER.Replace(p, para_value);
                }
            }

            PROC_PARAMETER = PROC_PARAMETER.Replace("@today", "'" + DateTime.Now.ToString("yyyy/MM/dd") + "'");
            PROC_PARAMETER = PROC_PARAMETER.Replace("@tomorrow", "'" + (DateTime.Now.AddDays(1).ToString("yyyy/MM/dd")) + "'");
        }

        public string Parse_Goods_Para()
        {
            List<string> para = PROC_PARAMETER.Split(',').Select(p => p.Trim()).ToList();

            foreach (string p in para)
            {
                if (p.Trim().StartsWith("$"))  return p;
            }

            return "";
        }

        public string Parse_Store_No(string str_no1, string str_no2 = "")
        {
            string str_para = PROC_PARAMETER;
            str_para = str_para.Replace("@str_no1", "'" + str_no1 + "'").Replace("@str_no2", "'" + str_no2 + "'");

            return str_para;
        } 
        
        public string Get_Proc_Para()
        {
            return PROC_PARAMETER;
        }     
    }

}
