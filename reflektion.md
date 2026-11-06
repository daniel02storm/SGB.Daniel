## Reflektion SGB Daniel Storm



###### Spelets struktur



9 scripts som består av PlayerController, MenuManager, GameManager, AudioManager, Fire, Enemy, Danger, Goal och MovingPlatform.



I PlayerController script hanteras movement, jumping, double jump och death.



I MenuManager får startmenyn inkludering i spelet samt användning genom att starta eller stänga spelet där den är en egen scene.



GameManager sköter text och knappar samt kan starta om scenen.



AudioManager är ganska self explanatory, där sköts all audio.



Danger har gjorts till en abstrakt klass som jag använder för allt som är en danger för spelaren, vilket Fire och Enemy använder ifrån, vilket är väldigt användbart om jag väljer att lägga till andra enemies i framtiden.



###### Event



Jag valde att göra mitt "Died" till ett public event action, den använder GameManager sig av när spelaren blir träffad av en enemy eller hazard. När spelaren dör så triggas min coroutine vilket först gör spelaren att blinka och sedan registrera att man är helt död.



###### Min Coroutine



Jag hade tidigare lite svårt att komma på hur jag skulle göra detta men sen kom jag på att i tidigare äldre spel brukar spelaren ha en blinking effect när man dör, vilket jag tyckte kändes coolt att få in här. Jag tror att det hade gått att göra utan en coroutine men det hade varit en längre lösning.



###### States



I mitt enemy script har jag tillagt två states i EnemyState för dom, valde att kalla dom för Chill och Angry. Kommer spelaren igenom 3 enhets thresholden så går deras angry igång och börjar jaga sitt victim, men endast medans du är i deras satta vision, flyr du så går dom tillbaka till sitt chill state.

Har även 3 states i gamemanager vilket är Playing, Won och Lost. Här ser den till att player inte kan röra på sig efter att man vinner eller förlorar, och att dom bara körs en gång.



###### Problem jag hade



* Hopp funkade inte alls i början och jag fattade inte alls varför så jag lät den vara ett tag, men det visade sig att mitt GroundCheck låg mitt i spelaren när den skulle vara på fötterna.
* Felstavningar i koden men det var snabbt löst med hjälp av visual studios verktyg.
* Min statustext visade bara "test" från början även fast jag trodde allt var kopplat så den visar text baserat på state, men jag fick läsa koden och löste det till slut där gamemanager saknade start.
* Mina enemies fastnade på staket som jag skapade för att hålla dom från att ramla, löste det genom att ändra transform.Translate till Rigidbody2D.linearVelocity så att staketet funkar som en vanlig vägg.
* Märkte senare i bygget att dödsljud och blinkning kunde hända även fast win har skett, så jag gjorde en lista för allDangers som stopar allt i dangers.



###### After thoughts



Hade gärna velat expandera på banan och göra en roligare level, eller att man kanske kan gå vidare till en level 2, men det kändes för svårt att ge mig in på. 

Ville dessutom ha en enemy som faller ner på marken vilket man måste passera med timing, men tror inte det fanns tid där för mig att fixa det.

Hade nog också varit bra att skapa ett event för när man vinner.

