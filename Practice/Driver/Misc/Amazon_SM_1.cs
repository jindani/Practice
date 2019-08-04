using System;
using System.Collections.Generic;
using System.Text;

namespace Misc
{

    
    public class Amazon_SM_1
    {
        class MyNode
        {
            public String s;
            public int index;
            public String identifier;
            public String version;
            public bool isOld;
            public MyNode(String s, int index)
            {
                this.s = s;
                this.index = index;
                int fIndex = s.IndexOf(" ");
                identifier = s.Substring(0, fIndex);
                version = s.Substring(fIndex + 1);
                isOld = IsAlpha(version);
            }
            public bool IsAlpha(String s)
            {
                foreach (char c in s)
                {
                    if ((c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z'))
                        return true;
                }
                return false;
            }
        }

        public List<string> orderedJunctionBoxes(int numberOfBoxes,
                                             string[] boxList)
        {

            MyNode[] boxes = new MyNode[numberOfBoxes];
            for(int i=0;i<numberOfBoxes;i++)
            {
                boxes[i] = new MyNode(boxList[i],i);
            }
            Array.Sort(boxes, delegate (MyNode f, MyNode s){
                if((f.isOld && !s.isOld))
                    return -1;
               
                if (!f.isOld && s.isOld)
                    return 1;
                if (!f.isOld && !s.isOld)
                    return f.index - s.index;
                int versionComp = f.version.CompareTo(s.version);
                if (versionComp == 0)
                {
                    int identifierComp = f.identifier.CompareTo(s.identifier);
                    if (identifierComp == 0)
                        return f.index - s.index;
                    return identifierComp;
                }

                return versionComp;
             });
            List<String> res = new List<String>();
            foreach (MyNode n in boxes)
            {
                Console.WriteLine(n.s + ":" +n.isOld);
                res.Add(n.s);
            }
                
            return res;
        }

        public static void Test()
        {
            String[] boxes = new string[] { "ykc 82 01","eo firsa qpx", "eo firs qpx", "09z cat hamster", "06f 12 25 6", "azO first qpx", "235 cat dog rabbit"};
            List<String> res =new Amazon_SM_1().orderedJunctionBoxes(6, boxes);
            
        }
    }
}
