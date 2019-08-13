grammar Expression;
exp
 : expression EOF
 ;

expression
 : yearlyselections	#queryx
 ;
 


yearlyselections
 : yearlyselection (and yearlyselection)*
 ;

yearlyselection
 : monthlyselections (OF yearselectors)?
 ;

yearselectors
 : yearselector (and yearselector)*
 ;

yearselector
 : EVERY YEAR
 | ordinals YEAR
 | numbers YEAR?
 | yearrangeselection
 ;

yearrangeselection
 : (EVERY YEAR)? FROM from=NUMBER TO to=NUMBER
 ;
 


monthlyselections
 : monthlyselection (and monthlyselection)*
 ;

monthlyselection
 : weeklyselections (OF monthsselectors)?
 | crossmonthrangeselection
 ;

monthsselectors
 : monthsselector (and monthsselector)*
 ;  

monthsselector
 : EVERY MONTH
 | ordinals MONTH
 | monthrangeselection
 | singlemonthselector
 ;

singlemonthselector
 : month
 | ordinal MONTH
 ;

monthrangeselection
 : (EVERY MONTH)? FROM from=month TO to=month
 ;

crossmonthrangeselection 
 : (EVERY DAY)? FROM from=pointinmonth TO to=pointinmonth
 ;

pointinmonth
 : ordinal (DAY? | dayofweek) OF singlemonthselector
 ;

month
 : JANUARY | FEBRUARY | MARCH | APRIL | MAY | JUNE | JULY | AUGUST | SEPTEMBER | OCTOBER | NOVEMBER | DECEMBER
 ;


 
weeklyselections
 : weeklyselection (and weeklyselection)*
 ;

weeklyselection
 : timeselections (OF weekselectors)?
 ;

weekselectors
 : EVERY WEEK
 | ordinals WEEK
 ; 



timeselections
 : timeselection (and timeselection)*
 ;

timeselection
 : EVERY DAY 
 | EVERY? daythenth
 | EVERY? daysofweek
 | ordinals daysofweek
 | ordinals DAY?
 | rangeselection
 ;

daythenth
 : dayofweek THE numeral
 ;

rangeselection
 : (EVERY DAY)? FROM from=pointintime TO to=pointintime
 ;

pointintime
 : ordinal (DAY? | dayofweek)
 ;

ordinals
 : ordinal (and ordinal)*
 ;

ordinal
 : FIRST | LAST | numeral
 ;

numerals
 : numeral (and numeral)*
 ;

numeral
 : NUMBER (ST | ND | RD | TH)
 ;

numbers
 : NUMBER (and NUMBER)*
 ;

daysofweek
 : dayofweek (and dayofweek)*
 ;

dayofweek
 : MONDAY | TUESDAY | WEDNESDAY | THURSDAY | FRIDAY | SATURDAY | SUNDAY
 ;

and
 : AND | COMMA
 ;

JANUARY			: [Jj][Aa][Nn][Uu][Aa][Rr][Yy] ;
FEBRUARY		: [Ff][Ee][Bb][Rr][Uu][Aa][Rr][Yy] ;
MARCH			: [Mm][Aa][Rr][Cc][Hh] ;
APRIL			: [Aa][Pp][Rr][Ii][Ll] ;
MAY				: [Mm][Aa][Yy] ;
JUNE			: [Jj][Uu][Nn][Ee] ;
JULY			: [Jj][Uu][Ll][Yy] ;
AUGUST			: [Aa][Uu][Gg][Uu][Ss][Tt] ;
SEPTEMBER		: [Ss][Ee][Pp][Tt][Ee][Mm][Bb][Ee][Rr] ;
OCTOBER			: [Oo][Cc][Tt][Oo][Bb][Ee][Rr] ;
NOVEMBER		: [Nn][Oo][Vv][Ee][Mm][Bb][Ee][Rr] ;
DECEMBER		: [Dd][Ee][Cc][Ee][Mm][Bb][Ee][Rr] ;

AND				: [Aa][Nn][Dd] ;
COMMA			: ',' ;
EVERY			: [Ee][Vv][Ee][Rr][Yy] ;
DAY				: [Dd][Aa][Yy] ;
MONDAY			: [Mm][Oo][Nn][Dd][Aa][Yy] ;
TUESDAY			: [Tt][Uu][Ee][Ss][Dd][Aa][Yy] ;
WEDNESDAY		: [Ww][Ee][Dd][Nn][Ee][Ss][Dd][Aa][Yy] ;
THURSDAY		: [Tt][Hh][Uu][Rr][Ss][Dd][Aa][Yy] ;
FRIDAY			: [Ff][Rr][Ii][Dd][Aa][Yy] ;
SATURDAY		: [Ss][Aa][Tt][Uu][Rr][Dd][Aa][Yy] ;
SUNDAY			: [Ss][Uu][Nn][Dd][Aa][Yy] ;
WEEK			: [Ww][Ee][Ee][Kk] ;
MONTH			: [Mm][Oo][Nn][Tt][Hh] ;
YEAR			: [Yy][Ee][Aa][Rr] ;
OF				: [Oo][Ff] ;
FROM			: [Ff][Rr][Oo][Mm] ;
TO				: [Tt][Oo] ;
THE				: [Tt][Hh][Ee];
FIRST			: [Ff][Ii][Rr][Ss][Tt] ;
LAST			: [Ll][Aa][Ss][Tt] ;
NUMBER			: [0-9]+ ;
ST				: [Ss][Tt] ;
ND				: [Nn][Dd] ;
RD				: [Rr][Dd] ;
TH				: [Tt][Hh] ;
WS				: [ \r\t\u000C\n]+ -> skip;