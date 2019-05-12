using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace De2_AI_Agent.TreeStore
{
    public class SentimentAnalysis
    {


        public int FindPositiveCount(string comment)
        {
            int Total = 0;
            string[] Positives = { "terrific","appreciate", "joy","love","loved", "happy", "good", "great", "fantastic", "superb", "excellent", "amazing", "wow", "awesome", "brilliant", "easy" };

            string[] args = comment.Split(new char[] { '.', '?', '!', ' ', ';', ':', ','}, StringSplitOptions.RemoveEmptyEntries);
            int len = Positives.Length;
            for(int i = 0; i < len; i++){

                var qeury = from r in args
                            where r.ToLowerInvariant() == Positives[i].ToLowerInvariant()
                            select r;
                Total += qeury.Count();
            }
            return Total;
        }

        public int FindNegativeCount(string comment)
        {
            int Total = 0;
            string[] Negatives = { "bad", "sucks", "crap", "fail", "failure"," rubbish"," ludacris","terrible","horror", "useless","anoying"};
            string[] args = comment.Split(new char[] { '.', '?', '!', ' ', ';', ':', ',', }, StringSplitOptions.RemoveEmptyEntries);
            int len = Negatives.Length;

            for (int i = 0; i < len; i++)
            {
                var qeury = from r in args
                            where r.ToLowerInvariant() == Negatives[i].ToLowerInvariant()
                            select r;
                Total += qeury.Count();
            }

            return Total;
        }


        public int DeterminePolarity(string comment)
        {

            int posCount = FindPositiveCount(comment);
            int negCount = FindNegativeCount(comment);

            int Total = 0;
            double percentage1, percentage2;
            if(posCount !=0 & negCount != 0)
            {

                Total = posCount + negCount;
                percentage1 = posCount / Total;
                percentage2 = negCount / Total;

                if (percentage1 > percentage2)
                {
                    return 1;
                }
                else if( percentage2 > percentage1)
                {
                    return -1;
                }
                else
                {
                    return 0;
                }
                

            }else if( posCount ==0 & negCount != 0)
            {
                return -1;
            }else if( posCount !=0 & negCount == 0)
            {
                return 1;
            }
            else
            {
                return 0;
            }

        }
    }
}