using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace mmfont.Net
{
    /// <summary>
    /// This Converter class two functions - Uni2ZG() and ZG2Uni() both accepting an input string.
    /// </summary>
    public static class Converter
    {
        private static List<Rule> UniRules
        {
            get
            {
                List<Rule> rules = new List<Rule>();
                rules.Add(new Rule("\u1004\u103a\u1039","\u1064"));
                rules.Add(new Rule("\u1039\u1010\u103d","\u1096"));
                rules.Add(new Rule("\u102b\u103a","\u105a"));
                rules.Add(new Rule("\u102d\u1036","\u108e"));
                rules.Add(new Rule("\u104e\u1004\u103a\u1038","\u104e"));
                rules.Add(new Rule("[\u1025\u1009](?=\u1039)","\u106a"));
                rules.Add(new Rule("\u1009(?=[\u102f\u1030])","\u1025"));
                rules.Add(new Rule("[\u1025\u1009](?=[\u1037]?[\u103a])","\u1025"));
                rules.Add(new Rule("\u100a(?=[\u1039\u103d])","\u106b"));
                rules.Add(new Rule("(\u1039[\u1000-\u1021])(\u102D)0,1}\u102f","$1$2\u1033"));
                rules.Add(new Rule("(\u1039[\u1000-\u1021])\u1030","$1\u1034"));
                rules.Add(new Rule("\u1014(?=[\u102d\u102e\u102f\u103A]?[\u1030\u103d\u103e\u102f\u1039])","\u108f"));
                rules.Add(new Rule("\u1014(?=\u103A\u102F )","\u108f"));
                rules.Add(new Rule("\u1014\u103c","\u108f\u103c"));
                rules.Add(new Rule("\u1039\u1000","\u1060"));
                rules.Add(new Rule("\u1039\u1001","\u1061"));
                rules.Add(new Rule("\u1039\u1002","\u1062"));
                rules.Add(new Rule("\u1039\u1003","\u1063"));
                rules.Add(new Rule("\u1039\u1005","\u1065"));
                rules.Add(new Rule("\u1039\u1006","\u1066"));
                rules.Add(new Rule("\u1039\u1007","\u1068"));
                rules.Add(new Rule("\u1039\u1008","\u1069"));
                rules.Add(new Rule("\u1039\u100b","\u106c"));
                rules.Add(new Rule("\u100b\u1039\u100c","\u1092"));
                rules.Add(new Rule("\u1039\u100c","\u106d"));
                rules.Add(new Rule("\u100d\u1039\u100d","\u106e"));
                rules.Add(new Rule("\u100d\u1039\u100e","\u106f"));
                rules.Add(new Rule("\u1039\u100f","\u1070"));
                rules.Add(new Rule("\u1039\u1010","\u1071"));
                rules.Add(new Rule("\u1039\u1011","\u1073"));
                rules.Add(new Rule("\u1039\u1012","\u1075"));
                rules.Add(new Rule("\u1039\u1013","\u1076"));
                rules.Add(new Rule("\u1039[\u1014\u108f]","\u1077"));
                rules.Add(new Rule("\u1039\u1015","\u1078"));
                rules.Add(new Rule("\u1039\u1016","\u1079"));
                rules.Add(new Rule("\u1039\u1017","\u107a"));
                rules.Add(new Rule("\u1039\u1018","\u107b"));
                rules.Add(new Rule("\u1039\u1019","\u107c"));
                rules.Add(new Rule("\u1039\u101c","\u1085"));
                rules.Add(new Rule("\u103f","\u1086"));
                rules.Add(new Rule("\u103d\u103e","\u108a"));
                rules.Add(new Rule("(\u1064)([\u1000-\u1021])([\u103b\u103c]?)\u102d","$2$3\u108b"));
                rules.Add(new Rule("(\u1064)([\u1000-\u1021])([\u103b\u103c]?)\u102e","$2$3\u108c"));
                rules.Add(new Rule("(\u1064)([\u1000-\u1021])([\u103b\u103c]?)\u1036","$2$3\u108d"));
                rules.Add(new Rule("(\u1064)([\u1000-\u1021\u1040-\u1049])([\u103b\u103c]?)([\u1031]?)","$2$3$4$1"));
                rules.Add(new Rule("\u101b(?=([\u102d\u102e]?)[\u102f\u1030\u103d\u108a])","\u1090"));
                rules.Add(new Rule("\u100f\u1039\u100d","\u1091"));
                rules.Add(new Rule("\u100b\u1039\u100b","\u1097"));
                rules.Add(new Rule("([\u1000-\u1021\u108f\u1029\u106e\u106f\u1086\u1090\u1091\u1092\u1097])([\u1060-\u1069\u106c\u106d\u1070-\u107c\u1085\u108a])?([\u103b-\u103e]*)?\u1031","\u1031$1$2$3"));
                rules.Add(new Rule("\u103c\u103e","\u103c\u1087"));
                rules.Add(new Rule("([\u1000-\u1021\u108f\u1029])([\u1060-\u1069\u106c\u106d\u1070-\u107c\u1085])?(\u103c)","$3$1$2"));
                rules.Add(new Rule("\u103a","\u1039"));
                rules.Add(new Rule("\u103b","\u103a"));
                rules.Add(new Rule("\u103c","\u103b"));
                rules.Add(new Rule("\u103d","\u103c"));
                rules.Add(new Rule("\u103e","\u103d"));
                rules.Add(new Rule("([^\u103a\u100a])\u103d([\u102d\u102e]?)\u102f","$1\u1088$2"));
                rules.Add(new Rule("([\u101b\u103a\u103c\u108a\u1088\u1090])([\u1030\u103d])?([\u1032\u1036\u1039\u102d\u102e\u108b\u108c\u108d\u108e]?)(\u102f)?\u1037","$1$2$3$4\u1095"));
                rules.Add(new Rule("([\u102f\u1014\u1030\u103d])([\u1032\u1036\u1039\u102d\u102e\u108b\u108c\u108d\u108e]?)\u1037","$1$2\u1094"));
                rules.Add(new Rule("([\u103b])([\u1000-\u1021])([\u1087]?)([\u1036\u102d\u102e\u108b\u108c\u108d\u108e]?)\u102f","$1$2$3$4\u1033"));
                rules.Add(new Rule("([\u103b])([\u1000-\u1021])([\u1087]?)([\u1036\u102d\u102e\u108b\u108c\u108d\u108e]?)\u1030","$1$2$3$4\u1034"));
                rules.Add(new Rule("([\u103a\u103c\u100a\u1008\u100b\u100c\u100d\u1020\u1025])([\u103d]?)([\u1036\u102d\u102e\u108b\u108c\u108d\u108e]?)\u102f","$1$2$3\u1033"));
                rules.Add(new Rule("([\u103a\u103c\u100a\u1008\u100b\u100c\u100d\u1020\u1025])(\u103d?)([\u1036\u102d\u102e\u108b\u108c\u108d\u108e]?)\u1030","$1$2$3\u1034"));
                rules.Add(new Rule("([\u100a\u1020\u1009])\u103d","$1\u1087"));
                rules.Add(new Rule("\u103d\u1030","\u1089"));
                rules.Add(new Rule("\u103b([\u1000\u1003\u1006\u100f\u1010\u1011\u1018\u101a\u101c\u101a\u101e\u101f])","\u107e$1"));
                rules.Add(new Rule("\u107e([\u1000\u1003\u1006\u100f\u1010\u1011\u1018\u101a\u101c\u101a\u101e\u101f])([\u103c\u108a])([\u1032\u1036\u102d\u102e\u108b\u108c\u108d\u108e])","\u1084$1$2$3"));
                rules.Add(new Rule("\u107e([\u1000\u1003\u1006\u100f\u1010\u1011\u1018\u101a\u101c\u101a\u101e\u101f])([\u103c\u108a])","\u1082$1$2"));
                rules.Add(new Rule("\u107e([\u1000\u1003\u1006\u100f\u1010\u1011\u1018\u101a\u101c\u101a\u101e\u101f])([\u1033\u1034]?)([\u1032\u1036\u102d\u102e\u108b\u108c\u108d\u108e])","\u1080$1$2$3"));
                rules.Add(new Rule("\u103b([\u1000-\u1021])([\u103c\u108a])([\u1032\u1036\u102d\u102e\u108b\u108c\u108d\u108e])","\u1083$1$2$3"));
                rules.Add(new Rule("\u103b([\u1000-\u1021])([\u103c\u108a])","\u1081$1$2"));
                rules.Add(new Rule("\u103b([\u1000-\u1021])([\u1033\u1034]?)([\u1032\u1036\u102d\u102e\u108b\u108c\u108d\u108e])","\u107f$1$2$3"));
                rules.Add(new Rule("\u103a\u103d","\u103d\u103a"));
                rules.Add(new Rule("\u103a([\u103c\u108a])","$1\u107d"));
                rules.Add(new Rule("([\u1033\u1034])(\u1036?)\u1094","$1$2\u1095"));
                rules.Add(new Rule("\u108F\u1071","\u108F\u1072"));
                rules.Add(new Rule("([\u1000-\u1021])([\u107B\u1066])\u102C","$1\u102C$2"));
                rules.Add(new Rule("\u102C([\u107B\u1066])\u1037","\u102C$1\u1094"));
                rules.Add(new Rule("\u1047((?=[\u1000-\u1021]\u1039)|(?=[\u102c-\u1030\u1032\u1036-\u1038\u103c\u103d]))","\u101b"));

                return rules;
            }
        }

        private static List<Rule> ZGRules
        {
            get
            {
                List<Rule> rules = new List<Rule>();
                rules.Add(new Rule("([\u102D\u102E\u103D\u102F\u1037\u1095])\\1+","$1"));
                rules.Add(new Rule("\u200B",""));
                rules.Add(new Rule("\u103d\u103c","\u108a"));
                rules.Add(new Rule("(\u103d|\u1087)","\u103e"));
                rules.Add(new Rule("\u103c","\u103d"));
                rules.Add(new Rule("(\u103b|\u107e|\u107f|\u1080|\u1081|\u1082|\u1083|\u1084)","\u103c"));
                rules.Add(new Rule("(\u103a|\u107d)","\u103b"));
                rules.Add(new Rule("\u1039","\u103a"));
                rules.Add(new Rule("(\u1066|\u1067)","\u1039\u1006"));
                rules.Add(new Rule("\u106a","\u1009"));
                rules.Add(new Rule("\u106b","\u100a"));
                rules.Add(new Rule("\u106c","\u1039\u100b"));
                rules.Add(new Rule("\u106d","\u1039\u100c"));
                rules.Add(new Rule("\u106e","\u100d\u1039\u100d"));
                rules.Add(new Rule("\u106f","\u100d\u1039\u100e"));
                rules.Add(new Rule("\u1070","\u1039\u100f"));
                rules.Add(new Rule("(\u1071|\u1072)","\u1039\u1010"));
                rules.Add(new Rule("\u1060","\u1039\u1000"));
                rules.Add(new Rule("\u1061","\u1039\u1001"));
                rules.Add(new Rule("\u1062","\u1039\u1002"));
                rules.Add(new Rule("\u1063","\u1039\u1003"));
                rules.Add(new Rule("\u1065","\u1039\u1005"));
                rules.Add(new Rule("\u1068","\u1039\u1007"));
                rules.Add(new Rule("\u1069","\u1039\u1008"));
                rules.Add(new Rule("(\u1073|\u1074)","\u1039\u1011"));
                rules.Add(new Rule("\u1075","\u1039\u1012"));
                rules.Add(new Rule("\u1076","\u1039\u1013"));
                rules.Add(new Rule("\u1077","\u1039\u1014"));
                rules.Add(new Rule("\u1078","\u1039\u1015"));
                rules.Add(new Rule("\u1079","\u1039\u1016"));
                rules.Add(new Rule("\u107a","\u1039\u1017"));
                rules.Add(new Rule("\u107c","\u1039\u1019"));
                rules.Add(new Rule("\u1085","\u1039\u101c"));
                rules.Add(new Rule("\u1033","\u102f"));
                rules.Add(new Rule("\u1034","\u1030"));
                rules.Add(new Rule("\u103f","\u1030"));
                rules.Add(new Rule("\u1086","\u103f"));
                rules.Add(new Rule("\u1036\u1088","\u1088\u1036"));
                rules.Add(new Rule("\u1088","\u103e\u102f"));
                rules.Add(new Rule("\u1089","\u103e\u1030"));
                rules.Add(new Rule("\u108a","\u103d\u103e"));
                rules.Add(new Rule("\u103B\u1064","\u1064\u103B"));
                rules.Add(new Rule("\u103c([\u1000-\u1021])(\u1064|\u108b)","$1\u103c$2"));
                rules.Add(new Rule("(\u1031)?([\u1000-\u1021\u1040-\u1049])(\u103c)?\u1064","\u1004\u103a\u1039$1$2$3"));
                rules.Add(new Rule("(\u1031)?([\u1000-\u1021])(\u103b|\u103c)?\u108b","\u1004\u103a\u1039$1$2$3\u102d"));
                rules.Add(new Rule("(\u1031)?([\u1000-\u1021])(\u103b)?\u108c","\u1004\u103a\u1039$1$2$3\u102e"));
                rules.Add(new Rule("(\u1031)?([\u1000-\u1021])(\u103b)?\u108d","\u1004\u103a\u1039$1$2$3\u1036"));
                rules.Add(new Rule("\u108e","\u102d\u1036"));
                rules.Add(new Rule("\u108f","\u1014"));
                rules.Add(new Rule("\u1090","\u101b"));
                rules.Add(new Rule("\u1091","\u100f\u1039\u100d"));
                rules.Add(new Rule("\u1092","\u100b\u1039\u100c"));
                rules.Add(new Rule("\u1019\u102c(\u107b|\u1093)","\u1019\u1039\u1018\u102c"));
                rules.Add(new Rule("(\u107b|\u1093)","\u1039\u1018"));
                rules.Add(new Rule("(\u1094|\u1095)","\u1037"));
                rules.Add(new Rule("([\u1000-\u1021])\u1037\u1032","$1\u1032\u1037"));
                rules.Add(new Rule("\u1096","\u1039\u1010\u103d"));
                rules.Add(new Rule("\u1097","\u100b\u1039\u100b"));
                rules.Add(new Rule("\u103c([\u1000-\u1021])([\u1000-\u1021])?","$1\u103c$2"));
                rules.Add(new Rule("([\u1000-\u1021])\u103c\u103a","\u103c$1\u103a"));
                rules.Add(new Rule("\u1047(?=[\u102c-\u1030\u1032\u1036-\u1038\u103d\u1038])","\u101b"));
                rules.Add(new Rule("\u1031\u1047","\u1031\u101b"));
                rules.Add(new Rule("\u1040(\u102e|\u102f|\u102d\u102f|\u1030|\u1036|\u103d|\u103e)","\u101d$1"));
                rules.Add(new Rule("([^\u1040\u1041\u1042\u1043\u1044\u1045\u1046\u1047\u1048\u1049])\u1040\u102b","$1\u101d\u102b"));
                rules.Add(new Rule("([\u1040\u1041\u1042\u1043\u1044\u1045\u1046\u1047\u1048\u1049])\u1040\u102b(?!\u1038)","$1\u101d\u102b"));
                rules.Add(new Rule("^\u1040(?=\u102b)","\u101d"));
                rules.Add(new Rule("\u1040\u102d(?!\u0020?/)","\u101d\u102d"));
                rules.Add(new Rule("([^\u1040-\u1049])\u1040([^\u1040-\u1049\u0020]|[\u104a\u104b])","$1\u101d$2"));
                rules.Add(new Rule("([^\u1040-\u1049])\u1040(?=[\\f\\n\\r])","$1\u101d"));
                rules.Add(new Rule("([^\u1040-\u1049])\u1040$","$1\u101d"));
                rules.Add(new Rule("\u1031([\u1000-\u1021\u103f])(\u103e)?(\u103b)?","$1$2$3\u1031"));
                rules.Add(new Rule("([\u1000-\u1021])\u1031([\u103b\u103c\u103d\u103e]+)","$1$2\u1031"));
                rules.Add(new Rule("\u1032\u103d","\u103d\u1032"));
                rules.Add(new Rule("([\u102d\u102e])\u103b","\u103b$1"));
                rules.Add(new Rule("\u103d\u103b","\u103b\u103d"));
                rules.Add(new Rule("\u103a\u1037","\u1037\u103a"));
                rules.Add(new Rule("\u102f(\u102d|\u102e|\u1036|\u1037)\u102f","\u102f$1"));
                rules.Add(new Rule("(\u102f|\u1030)(\u102d|\u102e)","$2$1"));
                rules.Add(new Rule("(\u103e)(\u103b|\u103c)","$2$1"));
                rules.Add(new Rule("\u1025(?=[\u1037]?[\u103a\u102c])","\u1009"));
                rules.Add(new Rule("\u1025\u102e","\u1026"));
                rules.Add(new Rule("\u1005\u103b","\u1008"));
                rules.Add(new Rule("\u1036(\u102f|\u1030)","$1\u1036"));
                rules.Add(new Rule("\u1031\u1037\u103e","\u103e\u1031\u1037"));
                rules.Add(new Rule("\u1031\u103e\u102c","\u103e\u1031\u102c"));
                rules.Add(new Rule("\u105a","\u102b\u103a"));
                rules.Add(new Rule("\u1031\u103b\u103e","\u103b\u103e\u1031"));
                rules.Add(new Rule("(\u102d|\u102e)(\u103d|\u103e)","$2$1"));
                rules.Add(new Rule("\u102c\u1039([\u1000-\u1021])","\u1039$1\u102c"));
                rules.Add(new Rule("\u1039\u103c\u103a\u1039([\u1000-\u1021])","\u103a\u1039$1\u103c"));
                rules.Add(new Rule("\u103c\u1039([\u1000-\u1021])","\u1039$1\u103c"));
                rules.Add(new Rule("\u1036\u1039([\u1000-\u1021])","\u1039$1\u1036"));
                rules.Add(new Rule("\u104e","\u104e\u1004\u103a\u1038"));
                rules.Add(new Rule("\u1040(\u102b|\u102c|\u1036)","\u101d$1"));
                rules.Add(new Rule("\u1025\u1039","\u1009\u1039"));
                rules.Add(new Rule("([\u1000-\u1021])\u103c\u1031\u103d","$1\u103c\u103d\u1031"));
                rules.Add(new Rule("([\u1000-\u1021])\u103b\u1031\u103d(\u103e)?","$1\u103b\u103d$2\u1031"));
                rules.Add(new Rule("([\u1000-\u1021])\u103d\u1031\u103b","$1\u103b\u103d\u1031"));
                rules.Add(new Rule("([\u1000-\u1021])\u1031(\u1039[\u1000-\u1021])","$1$2\u1031"));
                rules.Add(new Rule("\u1038\u103a","\u103a\u1038"));
                rules.Add(new Rule("\u102d\u103a|\u103a\u102d","\u102d"));
                rules.Add(new Rule("\u102d\u102f\u103a","\u102d\u102f"));
                rules.Add(new Rule("\u0020\u1037","\u1037"));
                rules.Add(new Rule("\u1037\u1036","\u1036\u1037"));
                rules.Add(new Rule("[\u102d]+","\u102d"));
                rules.Add(new Rule("[\u103a]+","\u103a"));
                rules.Add(new Rule("[\u103d]+","\u103d"));
                rules.Add(new Rule("[\u1037]+","\u1037"));
                rules.Add(new Rule("[\u102e]+","\u102e"));
                rules.Add(new Rule("\u102d\u102e|\u102e\u102d","\u102e"));
                rules.Add(new Rule("\u102f\u102d","\u102d\u102f"));
                rules.Add(new Rule("\u1037\u1037","\u1037"));
                rules.Add(new Rule("\u1032\u1032","\u1032"));
                rules.Add(new Rule("\u1044\u1004\u103a\u1038","\u104E\u1004\u103a\u1038"));
                rules.Add(new Rule("([\u102d\u102e])\u1039([\u1000-\u1021])","\u1039$2$1"));
                rules.Add(new Rule("(\u103c\u1031)\u1039([\u1000-\u1021])","\u1039$2$1"));
                rules.Add(new Rule("\u1036\u103d","\u103d\u1036"));
                rules.Add(new Rule("\u1047((?=[\u1000-\u1021]\u103a)|(?=[\u102c-\u1030\u1032\u1036-\u1038\u103d\u103e]))","\u101b"));

                return rules;
            }
        }

        /// <summary>
        /// Convert Unicode to Zawgyi
        /// </summary>
        /// <param name="Uni">Unicode string</param>
        /// <returns>Zawgyi string</returns>
        public static string Uni2ZG(string Uni)
        {
            return Convert(UniRules, Uni);
        }

        /// <summary>
        /// Convert Zawgyi to Unicode
        /// </summary>
        /// <param name="ZG">Zawgyi string</param>
        /// <returns>Unicode string</returns>
        public static string ZG2Uni(string ZG)
        {
            return Convert(ZGRules, ZG);
        }

        private static string Convert(List<Rule> Rules, string input)
        {
            foreach (Rule r in Rules)
            {
                Regex rgx = new Regex(r.From);
                input = rgx.Replace(input, r.To);
            }

            return input;
        }

    }

    class Rule
    {
        public string From { get; set; }
        public string To { get; set; }

        public Rule(string _From, string _To)
        {
            From = _From;
            To = _To;
        }
    }
}
