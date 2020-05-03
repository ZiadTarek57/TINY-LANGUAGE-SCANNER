using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scanner
{
    public class Scanner
    {
        public enum RESERVED_WORDS
        {
            T_INT, T_FLOAT, T_STRING, T_IF, T_THEN, T_ELSE, T_END, T_REPEAT,
            T_UNTIL, T_READ, T_WRITE, T_RETURN, T_ENDL
        };
        public enum SPECIAL_SYMBOLS
        {
            T_PLUS, T_MINUS, T_MULTIPLY, T_DIVIDE, T_EQUALTO, T_LESSTHAN, T_LEFTBRACKET,
            T_RIGHTBRACKET, T_LEFTBRACKE, T_RIGHTBRACKE, T_ARROR, T_ARRAND, T_SEMICOLON, T_QUOTE
        };
        public enum STATES
        {
            START, T_NUMBER, T_IDENTIFIER, T_ASSIGN, T_STARTCOMMENT, T_ENDCOMMENT, T_STRINGS, T_LOGOR, T_LOGAND,
            T_QUOTATION, SPECIALSYMBOLS, DONE
        };


        List<Token> tokensList = new List<Token>();

        public List<Token> getListOfTokens(string MyCode)
        {
            string state = STATES.START.ToString();
            string lastState = STATES.START.ToString();
            string currentTokenValue = "";
            int i = 0;
            while (true)
            {
                if (i > MyCode.Length - 1) break; //case end of my code is reached
                char character = MyCode[i];
                switch (state)
                {
                    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    case "START":
                        if (char.IsWhiteSpace(character))
                        {
                            state = STATES.START.ToString();
                        }
                        else if (char.IsDigit(character))
                        {
                            state = STATES.T_NUMBER.ToString();
                            currentTokenValue += character;
                        }
                        else if (char.IsLetter(character))
                        {
                            state = STATES.T_IDENTIFIER.ToString();
                            currentTokenValue += character;
                        }
                        else if (character == ':')
                        {
                            state = STATES.T_ASSIGN.ToString();
                            currentTokenValue += character;
                        }
                        else if (character == '/')
                        {
                            state = STATES.T_STARTCOMMENT.ToString();
                            currentTokenValue += character;
                        }
                        else if (character == '*')
                        {
                            state = STATES.T_ENDCOMMENT.ToString();
                            currentTokenValue += character;
                        }
                        else if (character == '"')
                        {
                            state = STATES.T_STRINGS.ToString();
                            currentTokenValue += character;
                        }
                        else if (character == '+' || character == '-' || character == '(' ||
                                 character == '=' || character == '<' || character == ')' ||
                                 character == '{' || character == '}' || character == ';')

                        {
                            currentTokenValue += character;
                            state = STATES.SPECIALSYMBOLS.ToString();
                        }
                        else if (character == '|')
                        {
                            state = STATES.T_LOGOR.ToString();
                            currentTokenValue += character;
                        }
                        else if (character == '&')
                        {
                            state = STATES.T_LOGAND.ToString();
                            currentTokenValue += character;
                        }
                        else
                        {
                            state = STATES.DONE.ToString();
                        }
                        lastState = state;
                        break;
                    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    case "T_NUMBER":
                        if (char.IsDigit(character))
                        {
                            currentTokenValue += character;
                            state = STATES.T_NUMBER.ToString();
                        }
                        else
                        {
                            state = STATES.DONE.ToString();
                        }
                        break;
                    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    case "T_IDENTIFIER":
                        if (((char.IsLetter(character)) || (char.IsDigit(character))) && (!(char.IsWhiteSpace(character))))
                        {
                            currentTokenValue += character;
                            state = STATES.T_IDENTIFIER.ToString();
                        }
                        else
                        {
                            state = STATES.DONE.ToString();
                        }
                        break;
                    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    case "T_ASSIGN":
                        if (character == '=')
                        {
                            currentTokenValue += character;
                            i++;
                            state = STATES.DONE.ToString();

                        }
                        else
                        {
                            state = STATES.SPECIALSYMBOLS.ToString();
                        }
                        break;
                    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    case "T_LOGOR":
                        if (character == '|')
                        {
                            currentTokenValue += character;
                            i++;
                            state = STATES.DONE.ToString();

                        }
                        else
                        {   
                            state = STATES.SPECIALSYMBOLS.ToString();
                        }
                        break;
                    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    case "T_LOGAND":
                        if (character == '&')
                        {
                            currentTokenValue += character;
                            i++;
                            state = STATES.DONE.ToString();

                        }
                        else
                        {
                            state = STATES.SPECIALSYMBOLS.ToString();
                        }
                        break;
                    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    case "SPECIALSYMBOLS":

                        
                        state = STATES.DONE.ToString();
                        
                      
                        break;
                    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    case "T_STARTCOMMENT":

                        if (character == '*')
                        {
                            currentTokenValue += character;
                            i++;
                            state = STATES.DONE.ToString();
                        }
                        else
                        {
                            
                            state = STATES.SPECIALSYMBOLS.ToString();
                          
                            
                        }
                        break;
                    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    case "T_ENDCOMMENT":

                        if (character == '/')
                        {
                            currentTokenValue += character;
                            i++;
                            state = STATES.DONE.ToString();
                        }
                        else
                        {
                            
                            state = STATES.SPECIALSYMBOLS.ToString();
                            i++;
                        }
                        break;

                    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    case "T_STRINGS":

                        if (character == '"')
                        {
                            currentTokenValue += character;
                            i++;
                            state = STATES.DONE.ToString();
                        }
                        else
                        {
                            currentTokenValue += character;
                            state = STATES.T_STRINGS.ToString();
                        }
                        break;
                    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    case "DONE":

                        Token token = new Token();
                        if (lastState == "SPECIALSYMBOLS")
                        {
                            token.tokenValue = currentTokenValue;
                            token.TokenType = getSpecialSymbolsTokenType(currentTokenValue);
                            //Console.WriteLine(currentTokenValue + "    " + token.TokenType);
                        }
                        else if (lastState == "T_IDENTIFIER")
                        {
                            token.tokenValue = currentTokenValue;
                            token.TokenType = getReservedWordsTokenType(currentTokenValue);
                            //Console.WriteLine(currentTokenValue + "    " + token.TokenType);
                        }
                        else
                        {
                            token.tokenValue = currentTokenValue;
                            token.TokenType = lastState;
                            //Console.WriteLine(currentTokenValue + "    " + lastState);
                        }
                        tokensList.Add(token);
                        currentTokenValue = "";
                        state = STATES.START.ToString();
                        lastState = STATES.DONE.ToString();
                        break;
                        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                }
                if (state == "DONE" || lastState == "DONE") { }
                else { i++; }
            }
            Token endOfTokens = new Token();
            endOfTokens.TokenType = "THEEND";
            endOfTokens.tokenValue = "$";
            tokensList.Add(endOfTokens);
            return tokensList;
        }

        public string getSpecialSymbolsTokenType(string value)
        {

            if (value[0] == '+') { return SPECIAL_SYMBOLS.T_PLUS.ToString(); }
            else if (value[0] == '-') { return SPECIAL_SYMBOLS.T_MINUS.ToString(); }
            else if (value[0] == '*') { return SPECIAL_SYMBOLS.T_MULTIPLY.ToString(); }
            else if (value[0] == '/') { return SPECIAL_SYMBOLS.T_DIVIDE.ToString(); }
            else if (value[0] == '=') { return SPECIAL_SYMBOLS.T_EQUALTO.ToString(); }
            else if (value[0] == '<') { return SPECIAL_SYMBOLS.T_LESSTHAN.ToString(); }
            else if (value[0] == ')') { return SPECIAL_SYMBOLS.T_RIGHTBRACKET.ToString(); }
            else if (value[0] == '(') { return SPECIAL_SYMBOLS.T_LEFTBRACKET.ToString(); }
            else if (value[0] == ';') { return SPECIAL_SYMBOLS.T_SEMICOLON.ToString(); }
            else if (value[0] == '{') { return SPECIAL_SYMBOLS.T_RIGHTBRACKE.ToString(); }
            else if (value[0] == '}') { return SPECIAL_SYMBOLS.T_LEFTBRACKE.ToString(); }
            else if (value[0] == '&') { return SPECIAL_SYMBOLS.T_ARRAND.ToString(); }
            else if (value[0] == '|') { return SPECIAL_SYMBOLS.T_ARROR.ToString(); }
            else if (value[0] == '"') { return SPECIAL_SYMBOLS.T_QUOTE.ToString(); }
            else return null;

        }



        public string getReservedWordsTokenType(string value)
        {

           /* if (value == "if") { return RESERVED_WORDS.T_IF.ToString(); }
            else if (value == "then") { return RESERVED_WORDS.T_THEN.ToString(); }
            else if (value == "else") { return RESERVED_WORDS.T_ELSE.ToString(); }
            else if (value == "end") { return RESERVED_WORDS.T_END.ToString(); }
            else if (value == "repeat") { return RESERVED_WORDS.T_REPEAT.ToString(); }
            else if (value == "until") { return RESERVED_WORDS.T_UNTIL.ToString(); }
            else if (value == "read") { return RESERVED_WORDS.T_READ.ToString(); }
            else if (value == "write") { return RESERVED_WORDS.T_WRITE.ToString(); }
            else if (value == "int") { return RESERVED_WORDS.T_INT.ToString(); }
            else if (value == "float") { return RESERVED_WORDS.T_FLOAT.ToString(); }
            else if (value == "string") { return RESERVED_WORDS.T_STRING.ToString(); }
            else if (value == "endl") { return RESERVED_WORDS.T_ENDL.ToString(); }
            else if (value == "return") { return RESERVED_WORDS.T_STRING.ToString(); }
            else return value + ".ID";*/
            
                        foreach (RESERVED_WORDS item in Enum.GetValues(typeof(RESERVED_WORDS)))
                        {
                            if (value == item.ToString().ToLower().Substring(2))
                            {
                                return item.ToString();
                            } 
                        }
                        return value + ".ID";
        }




    }
}


