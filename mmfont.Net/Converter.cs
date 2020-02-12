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
                rules.Add(new Rule("(\u103D|\u1087)", "\u103E"));
                rules.Add(new Rule("\u103C", "\u103D"));
                rules.Add(new Rule("(\u103B|\u107E|\u107F|\u1080|\u1081|\u1082|\u1083|\u1084)", "\u103C"));
                rules.Add(new Rule("(\u103A|\u107D)", "\u103B"));
                rules.Add(new Rule("\u1039", "\u103A"));
                rules.Add(new Rule("\u106A", "\u1009"));
                rules.Add(new Rule("\u106B", "\u100A"));
                rules.Add(new Rule("\u106C", "\u1039\u100B"));
                rules.Add(new Rule("\u106D", "\u1039\u100C"));
                rules.Add(new Rule("\u106E", "\u100D\u1039\u100D"));
                rules.Add(new Rule("\u106F", "\u100D\u1039\u100E"));
                rules.Add(new Rule("\u1070", "\u1039\u100F"));
                rules.Add(new Rule("(\u1071|\u1072)", "\u1039\u1010"));
                rules.Add(new Rule("\u1060", "\u1039\u1000"));
                rules.Add(new Rule("\u1061", "\u1039\u1001"));
                rules.Add(new Rule("\u1062", "\u1039\u1002"));
                rules.Add(new Rule("\u1063", "\u1039\u1003"));
                rules.Add(new Rule("\u1065", "\u1039\u1005"));
                rules.Add(new Rule("\u1068", "\u1039\u1007"));
                rules.Add(new Rule("\u1069", "\u1039\u1008"));
                rules.Add(new Rule("/(\u1073|\u1074)/g", "\u1039\u1011"));
                rules.Add(new Rule("\u1075", "\u1039\u1012"));
                rules.Add(new Rule("\u1076", "\u1039\u1013"));
                rules.Add(new Rule("\u1077", "\u1039\u1014"));
                rules.Add(new Rule("\u1078", "\u1039\u1015"));
                rules.Add(new Rule("\u1079", "\u1039\u1016"));
                rules.Add(new Rule("\u107A", "\u1039\u1017"));
                rules.Add(new Rule("\u107C", "\u1039\u1019"));
                rules.Add(new Rule("\u1085", "\u1039\u101C"));
                rules.Add(new Rule("\u1033", "\u102F"));
                rules.Add(new Rule("\u1034", "\u1030"));
                rules.Add(new Rule("\u103F", "\u1030"));
                rules.Add(new Rule("\u1086", "\u103F"));
                rules.Add(new Rule("\u1088", "\u103E\u102F"));
                rules.Add(new Rule("\u1089", "\u103E\u1030"));
                rules.Add(new Rule("\u108A", "\u103D\u103E"));
                rules.Add(new Rule("([\u1000-\u1021])\u1064", "\u1004\u103A\u1039$1"));
                rules.Add(new Rule("([\u1000-\u1021])\u108B", "\u1004\u103A\u1039$1\u102D"));
                rules.Add(new Rule("([\u1000-\u1021])\u108C", "\u1004\u103A\u1039$1\u102E"));
                rules.Add(new Rule("([\u1000-\u1021])\u108D", "\u1004\u103A\u1039$1\u1036"));
                rules.Add(new Rule("\u108E", "\u102D\u1036"));
                rules.Add(new Rule("\u108F", "\u1014"));
                rules.Add(new Rule("\u1090", "\u101B"));
                rules.Add(new Rule("\u1091", "\u100F\u1039\u1091"));
                rules.Add(new Rule("\u1019\u102C(\u107B|\u1093)", "\u1019\u1039\u1018\u102C"));
                rules.Add(new Rule("(\u107B|\u1093)", "\u103A\u1018"));
                rules.Add(new Rule("(\u1094|\u1095)", "\u1037"));
                rules.Add(new Rule("\u1096", "\u1039\u1010\u103D"));
                rules.Add(new Rule("\u1097", "\u100B\u1039\u100B"));
                rules.Add(new Rule("\u103C([\u1000-\u1021])([\u1000-\u1021])?", "$1\u103C$2"));
                rules.Add(new Rule("([\u1000-\u1021])\u103C\u103A", "\u103C$1\u103A"));
                rules.Add(new Rule("\u1031([\u1000-\u1021])(\u103E)?(\u103B)?", "$1$2$3\u1031"));
                rules.Add(new Rule("([\u1000-\u1021])\u1031(\u103B|\u103C|\u103D)", "$1$2\u1031"));
                rules.Add(new Rule("\u1032\u103D", "\u103D\u1032"));
                rules.Add(new Rule("\u103D\u103B", "\u103B\u103D"));
                rules.Add(new Rule("\u103A\u1037", "\u1037\u103A"));
                rules.Add(new Rule("\u102F(\u102D|\u102E|\u1036|\u1037)\u102F", "\u102F$1"));
                rules.Add(new Rule("\u102F\u102F", "\u102F"));
                rules.Add(new Rule("(\u102F|\u1030)(\u102D|\u102E)", "$2$1"));
                rules.Add(new Rule("(\u103E)(\u103B|\u1037)", "$2$1"));
                rules.Add(new Rule("\u1025(\u103A|\u102C)", "\u1009$1"));
                rules.Add(new Rule("\u1025\u102E", "\u1026"));
                rules.Add(new Rule("\u1005\u103B", "\u1008"));
                rules.Add(new Rule("\u1036(\u102F|\u1030)", "$1\u1036"));
                rules.Add(new Rule("\u1031\u1037\u103E", "\u103E\u1031\u1037"));
                rules.Add(new Rule("\u1031\u103E\u102C", "\u103E\u1031\u102C"));
                rules.Add(new Rule("\u105A", "\u102B\u103A"));
                rules.Add(new Rule("\u1031\u103B\u103E", "\u103B\u103E\u1031"));
                rules.Add(new Rule("(\u102D|\u102E)(\u103D|\u103E)", "$2$1"));
                rules.Add(new Rule("\u102C\u1039([\u1000-\u1021])", "\u1039$1\u102C"));
                rules.Add(new Rule("\u103C\u1004\u103A\u1039([\u1000-\u1021])", "\u1004\u103A\u1039$1\u103C"));
                rules.Add(new Rule("\u1039\u103C\u103A\u1039([\u1000-\u1021])", "\u103A\u1039$1\u103C"));
                rules.Add(new Rule("\u103C\u1039([\u1000-\u1021])", "\u1039$1\u103C"));
                rules.Add(new Rule("\u1036\u1039([\u1000-\u1021])", "\u1039$1\u1036"));
                rules.Add(new Rule("\u1092", "\u100B\u1039\u100C"));
                rules.Add(new Rule("\u104E", "\u104E\u1004\u103A\u1038"));
                rules.Add(new Rule("\u1040(\u102B|\u102C|\u1036)", "\u101D$1"));
                rules.Add(new Rule("\u1025\u1039", "\u1009\u1039"));

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
