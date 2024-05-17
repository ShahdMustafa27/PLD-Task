
using System;
using System.IO;
using System.Runtime.Serialization;
using com.calitha.goldparser.lalr;
using com.calitha.commons;

namespace com.calitha.goldparser
{

    [Serializable()]
    public class SymbolException : System.Exception
    {
        public SymbolException(string message) : base(message)
        {
        }

        public SymbolException(string message,
            Exception inner) : base(message, inner)
        {
        }

        protected SymbolException(SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }

    }

    [Serializable()]
    public class RuleException : System.Exception
    {

        public RuleException(string message) : base(message)
        {
        }

        public RuleException(string message,
                             Exception inner) : base(message, inner)
        {
        }

        protected RuleException(SerializationInfo info,
                                StreamingContext context) : base(info, context)
        {
        }

    }

    enum SymbolConstants : int
    {
        SYMBOL_EOF           =  0, // (EOF)
        SYMBOL_ERROR         =  1, // (Error)
        SYMBOL_WHITESPACE    =  2, // Whitespace
        SYMBOL_MINUS         =  3, // '-'
        SYMBOL_MINUSMINUS    =  4, // '--'
        SYMBOL_EXCLAMEQUAL   =  5, // '!equal'
        SYMBOL_LPAREN        =  6, // '('
        SYMBOL_RPAREN        =  7, // ')'
        SYMBOL_TIMES         =  8, // '*'
        SYMBOL_DOT           =  9, // '.'
        SYMBOL_DIV           = 10, // '/'
        SYMBOL_COLON         = 11, // ':'
        SYMBOL_SEMI          = 12, // ';'
        SYMBOL_CARET         = 13, // '^'
        SYMBOL_LBRACE        = 14, // '{'
        SYMBOL_RBRACE        = 15, // '}'
        SYMBOL_PLUS          = 16, // '+'
        SYMBOL_PLUSPLUS      = 17, // '++'
        SYMBOL_EQGT          = 18, // '=>'
        SYMBOL_DIGIT         = 19, // digit
        SYMBOL_DO            = 20, // do
        SYMBOL_ELSE          = 21, // else
        SYMBOL_END           = 22, // end
        SYMBOL_EQUAL         = 23, // equal
        SYMBOL_FORLOOP       = 24, // forloop
        SYMBOL_FUNC          = 25, // func
        SYMBOL_GREATER       = 26, // greater
        SYMBOL_ID            = 27, // id
        SYMBOL_IF            = 28, // if
        SYMBOL_LESS          = 29, // less
        SYMBOL_THEN          = 30, // then
        SYMBOL_WHILE         = 31, // while
        SYMBOL_ASSIGN        = 32, // <assign>
        SYMBOL_CONCEPT       = 33, // <concept>
        SYMBOL_CONDITION     = 34, // <condition>
        SYMBOL_DIGIT2        = 35, // <digit>
        SYMBOL_EXP           = 36, // <exp>
        SYMBOL_EXPRETION     = 37, // <expretion>
        SYMBOL_FACTOR        = 38, // <factor>
        SYMBOL_FOR           = 39, // <for>
        SYMBOL_ID2           = 40, // <id>
        SYMBOL_IF2           = 41, // <if>
        SYMBOL_METHOD        = 42, // <method>
        SYMBOL_METHODCALL    = 43, // <methodcall>
        SYMBOL_NAME          = 44, // <name>
        SYMBOL_OP            = 45, // <op>
        SYMBOL_PROGRAM       = 46, // <program>
        SYMBOL_STATMENT_LIST = 47, // <statment_list>
        SYMBOL_STEP          = 48, // <step>
        SYMBOL_TERM          = 49  // <term>
    };

    enum RuleConstants : int
    {
        RULE_PROGRAM_LBRACE_RBRACE                                  =  0, // <program> ::= '{' <statment_list> '}'
        RULE_PROGRAM_LBRACE_RBRACE2                                 =  1, // <program> ::= '{' <method> '}'
        RULE_STATMENT_LIST                                          =  2, // <statment_list> ::= <concept>
        RULE_STATMENT_LIST2                                         =  3, // <statment_list> ::= <concept> <statment_list>
        RULE_CONCEPT                                                =  4, // <concept> ::= <assign>
        RULE_CONCEPT2                                               =  5, // <concept> ::= <if>
        RULE_CONCEPT3                                               =  6, // <concept> ::= <for>
        RULE_CONCEPT4                                               =  7, // <concept> ::= <methodcall>
        RULE_ASSIGN_EQGT                                            =  8, // <assign> ::= <id> '=>' <expretion>
        RULE_ID_ID                                                  =  9, // <id> ::= id
        RULE_EXPRETION_PLUS                                         = 10, // <expretion> ::= <expretion> '+' <term>
        RULE_EXPRETION_MINUS                                        = 11, // <expretion> ::= <expretion> '-' <term>
        RULE_EXPRETION                                              = 12, // <expretion> ::= <term>
        RULE_TERM_TIMES                                             = 13, // <term> ::= <term> '*' <factor>
        RULE_TERM_DIV                                               = 14, // <term> ::= <term> '/' <factor>
        RULE_TERM                                                   = 15, // <term> ::= <factor>
        RULE_FACTOR_CARET                                           = 16, // <factor> ::= <factor> '^' <exp>
        RULE_FACTOR                                                 = 17, // <factor> ::= <exp>
        RULE_EXP_LPAREN_RPAREN                                      = 18, // <exp> ::= '(' <expretion> ')'
        RULE_EXP                                                    = 19, // <exp> ::= <id>
        RULE_EXP2                                                   = 20, // <exp> ::= <digit>
        RULE_DIGIT_DIGIT                                            = 21, // <digit> ::= digit
        RULE_IF_IF_LPAREN_RPAREN_THEN_SEMI                          = 22, // <if> ::= if '(' <condition> ')' then <statment_list> ';'
        RULE_IF_IF_LPAREN_RPAREN_THEN_SEMI_ELSE_DO_SEMI             = 23, // <if> ::= if '(' <condition> ')' then <statment_list> ';' else do <statment_list> ';'
        RULE_CONDITION                                              = 24, // <condition> ::= <expretion> <op> <expretion>
        RULE_OP_LESS                                                = 25, // <op> ::= less
        RULE_OP_GREATER                                             = 26, // <op> ::= greater
        RULE_OP_EQUAL                                               = 27, // <op> ::= equal
        RULE_OP_EXCLAMEQUAL                                         = 28, // <op> ::= '!equal'
        RULE_FOR_FORLOOP_LPAREN_ID_COLON_COLON_RPAREN_LBRACE_RBRACE = 29, // <for> ::= forloop '(' id ':' <condition> ':' <step> ')' '{' <statment_list> '}'
        RULE_FOR_WHILE                                              = 30, // <for> ::= while
        RULE_STEP_MINUSMINUS                                        = 31, // <step> ::= '--' <id>
        RULE_STEP_PLUSPLUS                                          = 32, // <step> ::= '++' <id>
        RULE_STEP                                                   = 33, // <step> ::= <assign>
        RULE_METHOD_FUNC_LPAREN_RPAREN_DO_END                       = 34, // <method> ::= func <name> '(' <assign> ')' do <statment_list> end
        RULE_METHOD_FUNC_LPAREN_RPAREN_DO_END2                      = 35, // <method> ::= func <name> '(' ')' do <statment_list> end
        RULE_NAME                                                   = 36, // <name> ::= <id>
        RULE_METHODCALL_FUNC_DOT_LPAREN_RPAREN                      = 37, // <methodcall> ::= func '.' <name> '(' ')'
        RULE_METHODCALL_FUNC_DOT_LPAREN_RPAREN2                     = 38  // <methodcall> ::= func '.' <name> '(' <digit> ')'
    };

    public class MyParser
    {
        private LALRParser parser;
        ListBox list;
        ListBox List2;
        public MyParser(string filename,ListBox list,ListBox list2)
        {
            FileStream stream = new FileStream(filename,
                                               FileMode.Open, 
                                               FileAccess.Read, 
                                               FileShare.Read);
            this.list = list;
            this.List2 = list2;
            Init(stream);
            stream.Close();
        } 

        public MyParser(string baseName, string resourceName)
        {
            byte[] buffer = ResourceUtil.GetByteArrayResource(
                System.Reflection.Assembly.GetExecutingAssembly(),
                baseName,
                resourceName);
            MemoryStream stream = new MemoryStream(buffer);
            Init(stream);
            stream.Close();
        }

        public MyParser(Stream stream)
        {
            Init(stream);
        }

        private void Init(Stream stream)
        {
            CGTReader reader = new CGTReader(stream);
            parser = reader.CreateNewParser();
            parser.TrimReductions = false;
            parser.StoreTokens = LALRParser.StoreTokensMode.NoUserObject;

            parser.OnTokenError += new LALRParser.TokenErrorHandler(TokenErrorEvent);
            parser.OnParseError += new LALRParser.ParseErrorHandler(ParseErrorEvent);
            parser.OnTokenRead += new LALRParser.TokenReadHandler(TokenReadEvent);
        }

        public void Parse(string source)
        {
            NonterminalToken token = parser.Parse(source);
            if (token != null)
            {
                Object obj = CreateObject(token);
                //todo: Use your object any way you like
            }
        }

        private Object CreateObject(Token token)
        {
            if (token is TerminalToken)
                return CreateObjectFromTerminal((TerminalToken)token);
            else
                return CreateObjectFromNonterminal((NonterminalToken)token);
        }

        private Object CreateObjectFromTerminal(TerminalToken token)
        {
            switch (token.Symbol.Id)
            {
                case (int)SymbolConstants.SYMBOL_EOF :
                //(EOF)
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ERROR :
                //(Error)
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_WHITESPACE :
                //Whitespace
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_MINUS :
                //'-'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_MINUSMINUS :
                //'--'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EXCLAMEQUAL :
                //'!equal'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LPAREN :
                //'('
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_RPAREN :
                //')'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_TIMES :
                //'*'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DOT :
                //'.'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DIV :
                //'/'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_COLON :
                //':'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_SEMI :
                //';'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CARET :
                //'^'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LBRACE :
                //'{'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_RBRACE :
                //'}'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PLUS :
                //'+'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PLUSPLUS :
                //'++'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EQGT :
                //'=>'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DIGIT :
                //digit
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DO :
                //do
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ELSE :
                //else
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_END :
                //end
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EQUAL :
                //equal
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FORLOOP :
                //forloop
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FUNC :
                //func
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_GREATER :
                //greater
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ID :
                //id
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_IF :
                //if
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LESS :
                //less
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_THEN :
                //then
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_WHILE :
                //while
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ASSIGN :
                //<assign>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CONCEPT :
                //<concept>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CONDITION :
                //<condition>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DIGIT2 :
                //<digit>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EXP :
                //<exp>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EXPRETION :
                //<expretion>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FACTOR :
                //<factor>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FOR :
                //<for>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ID2 :
                //<id>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_IF2 :
                //<if>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_METHOD :
                //<method>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_METHODCALL :
                //<methodcall>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_NAME :
                //<name>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_OP :
                //<op>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PROGRAM :
                //<program>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_STATMENT_LIST :
                //<statment_list>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_STEP :
                //<step>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_TERM :
                //<term>
                //todo: Create a new object that corresponds to the symbol
                return null;

            }
            throw new SymbolException("Unknown symbol");
        }

        public Object CreateObjectFromNonterminal(NonterminalToken token)
        {
            switch (token.Rule.Id)
            {
                case (int)RuleConstants.RULE_PROGRAM_LBRACE_RBRACE :
                //<program> ::= '{' <statment_list> '}'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_PROGRAM_LBRACE_RBRACE2 :
                //<program> ::= '{' <method> '}'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STATMENT_LIST :
                //<statment_list> ::= <concept>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STATMENT_LIST2 :
                //<statment_list> ::= <concept> <statment_list>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CONCEPT :
                //<concept> ::= <assign>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CONCEPT2 :
                //<concept> ::= <if>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CONCEPT3 :
                //<concept> ::= <for>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CONCEPT4 :
                //<concept> ::= <methodcall>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ASSIGN_EQGT :
                //<assign> ::= <id> '=>' <expretion>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ID_ID :
                //<id> ::= id
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPRETION_PLUS :
                //<expretion> ::= <expretion> '+' <term>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPRETION_MINUS :
                //<expretion> ::= <expretion> '-' <term>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPRETION :
                //<expretion> ::= <term>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TERM_TIMES :
                //<term> ::= <term> '*' <factor>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TERM_DIV :
                //<term> ::= <term> '/' <factor>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TERM :
                //<term> ::= <factor>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FACTOR_CARET :
                //<factor> ::= <factor> '^' <exp>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FACTOR :
                //<factor> ::= <exp>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXP_LPAREN_RPAREN :
                //<exp> ::= '(' <expretion> ')'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXP :
                //<exp> ::= <id>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXP2 :
                //<exp> ::= <digit>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_DIGIT_DIGIT :
                //<digit> ::= digit
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_IF_IF_LPAREN_RPAREN_THEN_SEMI :
                //<if> ::= if '(' <condition> ')' then <statment_list> ';'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_IF_IF_LPAREN_RPAREN_THEN_SEMI_ELSE_DO_SEMI :
                //<if> ::= if '(' <condition> ')' then <statment_list> ';' else do <statment_list> ';'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CONDITION :
                //<condition> ::= <expretion> <op> <expretion>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_OP_LESS :
                //<op> ::= less
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_OP_GREATER :
                //<op> ::= greater
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_OP_EQUAL :
                //<op> ::= equal
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_OP_EXCLAMEQUAL :
                //<op> ::= '!equal'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FOR_FORLOOP_LPAREN_ID_COLON_COLON_RPAREN_LBRACE_RBRACE :
                //<for> ::= forloop '(' id ':' <condition> ':' <step> ')' '{' <statment_list> '}'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FOR_WHILE :
                //<for> ::= while
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STEP_MINUSMINUS :
                //<step> ::= '--' <id>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STEP_PLUSPLUS :
                //<step> ::= '++' <id>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STEP :
                //<step> ::= <assign>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_METHOD_FUNC_LPAREN_RPAREN_DO_END :
                //<method> ::= func <name> '(' <assign> ')' do <statment_list> end
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_METHOD_FUNC_LPAREN_RPAREN_DO_END2 :
                //<method> ::= func <name> '(' ')' do <statment_list> end
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_NAME :
                //<name> ::= <id>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_METHODCALL_FUNC_DOT_LPAREN_RPAREN :
                //<methodcall> ::= func '.' <name> '(' ')'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_METHODCALL_FUNC_DOT_LPAREN_RPAREN2 :
                //<methodcall> ::= func '.' <name> '(' <digit> ')'
                //todo: Create a new object using the stored tokens.
                return null;

            }
            throw new RuleException("Unknown rule");
        }

        private void TokenErrorEvent(LALRParser parser, TokenErrorEventArgs args)
        {
            string message = "Token error with input: '"+args.Token.ToString()+"'";
            //todo: Report message to UI?
        }

        private void ParseErrorEvent(LALRParser parser, ParseErrorEventArgs args)
        {
            string message = "Parse error caused by token: '"+args.UnexpectedToken.ToString()+"'"+"  in line number:" + args.UnexpectedToken.Location.LineNr;
            list.Items.Add(message);
            string m2 ="Expected token: " + args.ExpectedTokens.ToString();
            list.Items.Add(m2);
            //todo: Report message to UI?
        }

        private void TokenReadEvent(LALRParser parser, TokenReadEventArgs args)
        {
            string info = args.Token.Text + "               " + (SymbolConstants)args.Token.Symbol.Id;

            List2.Items.Add(info);
        }

    }
    
}
