using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace De2_AI_Agent.TreeStore
{
    public class SentimentAnalysis
    {


        public void FindPositiveCount(string comment)
        {
            int Total = 0;
            string[] Positives = { "terrific", "joy","love","loved", "happy", "good", "great", "fantastic", "superb", "excellent", "amazing", "wow", "awesome", "brilliant", "easy" };

            string[] args = comment.Split(new char[] { '.', '?', '!', ' ', ';', ':', ',', }, StringSplitOptions.RemoveEmptyEntries);
            int len = Positives.Length;
            for(int i = 0; i < len; i++){

                var qeury = from r in args
                            where r.ToLowerInvariant() == Positives[i].ToLowerInvariant()
                            select r;
                Total += qeury.Count();
            }
           
        }

        public void FindNegativeCount(string comment)
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

        }


        public void DeterminePolarity(string comment)
        {




        }
    }
}