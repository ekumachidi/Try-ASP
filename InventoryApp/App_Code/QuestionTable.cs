using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Collections;
/// <summary>
/// Summary description for QuestionTable
/// </summary>
public class QuestionTable
{
	public QuestionTable()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public static DataTable GetQuestionBySubject(string subject)
    {
        DataTable dtTable = new DataTable();
        dtTable.Clear();
        dtTable.Columns.Add("SN");
        dtTable.Columns.Add("REFERENCE_TEXT");
        dtTable.Columns.Add("REFERENCE_IMAGE");
        dtTable.Columns.Add("IS_OPTION_IMAGE");
        dtTable.Columns.Add("IS_BONUS");
        dtTable.Columns.Add("QUESTION");
        dtTable.Columns.Add("OPTION_A");
        dtTable.Columns.Add("OPTION_B");
        dtTable.Columns.Add("OPTION_C");
        dtTable.Columns.Add("OPTION_D");
        dtTable.Columns.Add("OPTION_E");
        dtTable.Columns.Add("ANSWER_CHOICE");
        dtTable.Columns.Add("ANSWER_POINT");
        dtTable.Columns.Add("SUBJECT");
        dtTable.Columns.Add("OPTION_A_CHOICE");
        dtTable.Columns.Add("OPTION_B_CHOICE");
        dtTable.Columns.Add("OPTION_C_CHOICE");
        dtTable.Columns.Add("OPTION_D_CHOICE");
        dtTable.Columns.Add("OPTION_E_CHOICE");
        dtTable.Columns.Add("ANSWERED");
        dtTable.Columns.Add("CURSOR");
        string questionid ="";
        string[] Option ={"0","0","0","0","0"};
        string[] Choice = { "0", "0", "0", "0", "0" };
        string ReferenceText = "";
        string ReferenceImage = "";
        string Questions = "";
        string IsOptionImage = "";
        string IsBonus = "";
        string AnswerPoint = "";
        string questionchoice = "";
        string AnswerChoice = "";

        try
        {
            DataSet dsData = ConnectDB.LoadDatasource("Select DISTINCT QUESTION_ID from VW_QUESTIONS where Activated ='True' and SUBJECT_ID ='" + subject + "'");
            if (dsData != null)
            {
                if (dsData.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < dsData.Tables[0].Rows.Count; i++)
                    {
                        questionid =Convert.ToString(dsData.Tables[0].Rows[i]["QUESTION_ID"]);
                        DataSet dsQuestion = ConnectDB.LoadDatasource("select * from  VW_QUESTIONS where Activated ='True' and SUBJECT_ID ='" + subject + "' and QUESTION_ID ='" + questionid + "' order by newid()");
                        if (dsQuestion != null)
                        {
                            if (dsQuestion.Tables[0].Rows.Count > 0)
                            {
                                ReferenceText = Convert.ToString(dsQuestion.Tables[0].Rows[0]["REFERENCE_TEXT"]);
                                ReferenceImage = Convert.ToString(dsQuestion.Tables[0].Rows[0]["REFERENCE_IMAGE"]);
                                Questions = Convert.ToString(dsQuestion.Tables[0].Rows[0]["QUESTION"]);
                                IsOptionImage = Convert.ToString(dsQuestion.Tables[0].Rows[0]["IS_OPTION_IMAGE"]);
                                IsBonus = Convert.ToString(dsQuestion.Tables[0].Rows[0]["IS_BONUS"]);
                                AnswerPoint = Convert.ToString(dsQuestion.Tables[0].Rows[0]["ANSWER_POINTS"]);
                                AnswerChoice = Convert.ToString(dsQuestion.Tables[0].Rows[0]["ANSWER_CHOICE"]);

                                for (int j = 0; j < dsQuestion.Tables[0].Rows.Count; j++)
                                {
                                    Option[j] = Convert.ToString(dsQuestion.Tables[0].Rows[j]["QUESTION_OPTION"]);
                                    Choice[j] = Convert.ToString(dsQuestion.Tables[0].Rows[j]["QUESTION_CHOICE"]);

                                }

                            }
                        }

                        dtTable.Rows.Add(Convert.ToString(i + 1), ReferenceText, ReferenceImage, IsOptionImage, IsBonus, Questions, Option[0], Option[1], Option[2], Option[3], Option[4], AnswerChoice, AnswerPoint, subject, Choice[0], Choice[1], Choice[2], Choice[3], Choice[4],"","");

                      }
                }
            }

        }
        catch (Exception ex)
        {
            
            throw ex;
        }


        return dtTable;
    }

}