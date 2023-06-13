# inVen

inVen steht für das englische Wort "Inventory" und ist eine Software zur Verwaltung von simplen kleinen Lagern.
Bitte habt Nachsicht denn inVen ist eines meiner früheren Projekte und entstand eher aus der Langeweile heraus weil ich es mir einfacher machen wollte meine
eigenen "Produkte" zu verwalten usw.

inVen bietet einiges an kleinen Funktionen. Zum einen kann man separate Datenbanken anlegen die praktisch eine Zusammenstellung eigener Inventare beinhaltet.
Es lassen sich kleine Lieferscheine generieren und man kann Daten aus CSV formaten übernehmen. Nichts Wildes aber immerhin :-)

![image](https://github.com/BlackFoX1991/inVen/assets/125445926/f008da41-5ac6-445d-b187-ad2fcd1704ff)
Im ersten Schritt legt Ihr wie beschrieben eine eigene Datenbank an. Bitte merkt euch die Passwörter gut denn die Daten werden
später im AES Verfahren damit verschlüsselt. Im Backend wird eure Datenbank eure Datenbank dann in eine xjson Datei gespeichert die aus mehreren
verschlüsselten Datensätzen besteht.


![image](https://github.com/BlackFoX1991/inVen/assets/125445926/151d426c-f791-46d0-ba7f-4c36f456bedd)
![image](https://github.com/BlackFoX1991/inVen/assets/125445926/2d1b28cf-d236-4d24-a212-51534624809a)
Im zweiten Schritt können wir auch schon anfangen Inventare anzulegen, um das Anmerkungs-Feld freizuschalten müsst Ihr während ihr
im Textfeld des Lagernamens seid "F2" drücken. Seid Ihr fertig drückt "F9" oder klickt auf "Weiter".


Im nächsten Schritt markiert Ihr euer Inventar und öffnet mit einem Rechtsklick in der rechten Liste das Menü.
Dort können dann auch schon Artikel in euer Inventar eingepeist werden.
![image](https://github.com/BlackFoX1991/inVen/assets/125445926/3f787aad-e63b-4b08-a94d-ef5c10a49825)
![image](https://github.com/BlackFoX1991/inVen/assets/125445926/4d5b7211-7ca8-4c1b-bc20-796afe3987e4)

aber moment mal, natürlich sollen Artikel nicht nur aus Nummern oder Namen bestehen sondern brauchen auch noch Hintergrundinfos...
Um das zu ändern gibt es 2 Möglichkeiten, zum einen geht Ihr in die Eigenschaften eurer Datenbank oder Ihr lasst euch den Artikel anzeigen
worauf euch inVen dann nach einem neuen Eintrag fragt da wir Diese in unserem Beispiel noch nicht angelegt haben.
![image](https://github.com/BlackFoX1991/inVen/assets/125445926/85415791-cb94-41ae-b22f-7e14b0694df0)
![image](https://github.com/BlackFoX1991/inVen/assets/125445926/795d0a49-e116-45fb-a2da-c9252c07ed02)


Im folgenden Dialog können wir nun Produkt-ID, Produkt-Gruppe sowie Spezifikationen, Preis und Beschreibung festlegen
![image](https://github.com/BlackFoX1991/inVen/assets/125445926/f66122b5-3622-4e75-a49b-ec38b67230c8)


Bilder werden aus dem Ordner "data/images" im selben Verzeichnis wie inVen sich befindet geladen, egal ob png oder jpg.
Das Bild sollte die ID als Dateinamen haben und werden entsprechend geladen.
![image](https://github.com/BlackFoX1991/inVen/assets/125445926/ebba82d9-f25e-4915-8cc7-55589234faab)


Hier nochmal die Eigenschaften zur Datenbank, wo man unteranderem den Author und die Beschreibung der Datenbank festlegen kann.
Dort findet man u.a. die Stammdaten der Artikel die wir zuvor eingepflegt hatten. Ja Die Artikel sind pro Datenbank anzulegen.
![image](https://github.com/BlackFoX1991/inVen/assets/125445926/4bb132a3-7e07-4de3-9917-6230176b8c7a)
![image](https://github.com/BlackFoX1991/inVen/assets/125445926/6b90d404-5eb1-47cd-8515-4d6ac8080a55)


( Weitere Schritte folgen die nächsten Tage/ Stunden... )





