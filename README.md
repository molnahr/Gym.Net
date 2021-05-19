## Fitness termek bérletrendszere

Adott egy Fitness terem részleges adatbázisának a relációi.
BerletTipusok(berlet_id, megnevezes, ar, hanynapigervenyes, hanybelepesreervenyes, torolve, terem_id, Hanyoratol,
Hanyoraig, Napontahanyszorhasznalhato);
Kliensek(Kliens_id, nev, telefon, email, is_deleted, photo, inserted_date, szemelyi, cim, vonalkód, Megjegyzesek);
Belepesek(belepes_id, Kliens_id, berlet_id,datum, insertedby_uid, barcode, terem_id);
KliensBerletei(kliens_berleteiei_id, kliens_id, berlet_id, vasarlasi_datum, vonalkód, EddigiBelepesszam, eladasiar,
Ervenyes, ElsoHasznalat_datum, terem_id);
FTermek(terem_id, nev, is_deleted);
A software célja a fitness termek bérleteinek kiadására és ezek használatának könnyebb követése.
A software felhasználóbarát kell legyen és átlátható. Nagy karaktereket kell használni, vonzó, modern felületet,
nagy méretű gombokat, hogy a software használat kevés számítógép ismerettel rendelkező személyek számára is
elérhető legyen.
A software funkciói:
1. Kliensek: kliensek hozzáadása, módosítása, törlése és keresése. Kliens hozzáadásakor eltároljuk a kliens
adatait. (fényképet is pl. webcamről). Új kliens bevezetésekor egyből lehessen neki bérletet adni.
2. Bérlet típusok: bérlet típusok létrehozása, ezek módosítása és törlése (vagy inaktiválása). Létezik
adott időtartamra érvényes bérlet (pl. 10 nap, 30 nap), adott belépés számra érvényes bérlet (pl. 10
alkalom, 20 alkalom) és ezeknek a kombinált változata (pl. 30 nap, de maximum 10 alkalom). A
bérleteknek lehet olyan megszorítása is, hogy egy nap max hányszor lehet használni és olyan is, hogy csak
bizonyos órák között érvényes (pl. 8-12), vagy, hogy milyen napokon (pl. lehet csak hétvégén érvényes)
3. KliensekBérletei: kliens kiválasztása (név vagy vonalkód alapján), bérlet típus. Egy kliensnek lehet több
bérlete is ugyanazzal a kártyával. Ki lehet választani milyen dátumtól lesz érvényes a bérlet.
4. Belépések követése: a kliens kártyaszámának beütésekor feljönnek a képernyőre az adatai (fénykép is ha
van). Itt lehet megnézni azt, hogyha az illető bérlet még érvényes vagy sem, és mikor van a lejárati ideje.
Hogyha az kliens belép a terembe akkor egy gomb nyomással nyugtázzuk ezt és a bérlet használata rögzül
az adatbázisban (pl. a fennmaradó belépések száma csökken 1-el, vagy ha időszakos bérlet akkor csak
rögzítjük hogy az kliens ezen a napon a teremben járt). Hogyha bérlet már nem érvényes akkor ez az
információ jelenik meg a képernyőn és nincs “Belépés” nevű gomb (vagy inaktív)
5. Kimutatások:
a. Ügyfelek listázása, minden adattal (a listákat lehessen xls típus fileba exportálni)
b. Bérletek listázása (szűrők: aktív/lejárt, típus szerint, idő a lejáratig, aktiválás dátum tól-ig)
c. Belépések listázása: mikor voltak használva az érvényes bérletek (szűrők: kliens neve,
kártyaszám, bérlet típus, dátum). Pl. érdekes lehet, hogy egy adott napon kik voltak akik bérlettel,
vagy bizonyos típus bérlettel léptek be a terembe

Módosításkor és törléskor figyelni kell arra, hogy a módosított adatok, hogyan befolyásolják a tárolt adatokat. Pl.
egy bérlet típusnak kitörlésekor hogyan tudjuk kilistázni azokat az adatokat amik ehhez a bérletípushoz tartoztak.
(javasoltabb az inaktiválás)
Továbbá:
- E-mail: e-mail küldése az összes felhasználónak,
- Fénykép készítése webcamről
- Felhasználók: a rendszer két szintű felhasználó (admin és user) számára elérhető. A felhasználók
managementje. A User típusú felhasználók számára nem elérhetőek a riportolási és a felhasználó
management modulok, helyesebben csak a saját eladásait látja, de másét nem. A bérlet típusokat csak
az Admin tudja módosítani.

1. Belépés
a. Írja ki, hogy a bérlet Mettől Meddig érvényes
b. Belépés szám 30/26 (tehát mennyi volt eredetileg és mennyi van most)
c. VonalKód olvasása után a név mezőben is jelenjen meg a név
d. Amikor a kártyát leolvassák, akkor lehessen kiválasztani melyik bérletet használja
e. Belépés után jelenjen meg egy ablak, hogy sikeresen belépett-e az illető és az, hogy hány belépése van
még.
f. Hogyha név szerint keresünk akkor a név után egyéb adat is jelenjen meg, pl. telefonszám vagy
emailcím. Több ugyanolyan nevű személy is lehet
g. Lejárt Bérlet nagy betűkkel és pirossal.
h. Figyelmeztetés jöjjön előre hogyha valakinek 2 napja vagy 1 belépése van hátra.
