-- phpMyAdmin SQL Dump
-- version 5.1.0
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Erstellungszeit: 28. Jan 2022 um 09:28
-- Server-Version: 10.4.19-MariaDB
-- PHP-Version: 7.4.19

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Datenbank: `instrumentenverleih`
--

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `ausgeliehen`
--

CREATE TABLE `ausgeliehen` (
  `Instrument_FK` int(11) NOT NULL,
  `Kunden_FK` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `hersteller`
--

CREATE TABLE `hersteller` (
  `ID` int(11) NOT NULL,
  `Name` varchar(255) COLLATE utf8_bin NOT NULL,
  `PLZ` int(11) NOT NULL,
  `Ort` varchar(255) COLLATE utf8_bin NOT NULL,
  `Straße/Nr.` varchar(255) COLLATE utf8_bin NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;

--
-- Daten für Tabelle `hersteller`
--

INSERT INTO `hersteller` (`ID`, `Name`, `PLZ`, `Ort`, `Straße/Nr.`) VALUES
(1, 'Huh', 53498, 'Bad Breisig', 'Wallers');

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `instrument`
--

CREATE TABLE `instrument` (
  `ID` int(11) NOT NULL,
  `Name` varchar(255) COLLATE utf8_bin NOT NULL,
  `HerstellerFK` int(11) NOT NULL,
  `Preis` int(11) NOT NULL,
  `Ausgeliehen` tinyint(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;

--
-- Daten für Tabelle `instrument`
--

INSERT INTO `instrument` (`ID`, `Name`, `HerstellerFK`, `Preis`, `Ausgeliehen`) VALUES
(1, 'Violine', 1, 100, 0);

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `kunden`
--

CREATE TABLE `kunden` (
  `ID` int(11) NOT NULL,
  `Name` varchar(255) COLLATE utf8_bin NOT NULL,
  `Vorname` varchar(255) COLLATE utf8_bin NOT NULL,
  `Adresse_fk` int(11) NOT NULL,
  `Tarif_fk` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;

--
-- Indizes der exportierten Tabellen
--

--
-- Indizes für die Tabelle `ausgeliehen`
--
ALTER TABLE `ausgeliehen`
  ADD KEY `Instrument_FK` (`Instrument_FK`),
  ADD KEY `Kunden_FK` (`Kunden_FK`);

--
-- Indizes für die Tabelle `hersteller`
--
ALTER TABLE `hersteller`
  ADD PRIMARY KEY (`ID`);

--
-- Indizes für die Tabelle `instrument`
--
ALTER TABLE `instrument`
  ADD PRIMARY KEY (`ID`),
  ADD KEY `HerstellerFK` (`HerstellerFK`);

--
-- Indizes für die Tabelle `kunden`
--
ALTER TABLE `kunden`
  ADD PRIMARY KEY (`ID`);

--
-- AUTO_INCREMENT für exportierte Tabellen
--

--
-- AUTO_INCREMENT für Tabelle `hersteller`
--
ALTER TABLE `hersteller`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT für Tabelle `instrument`
--
ALTER TABLE `instrument`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT für Tabelle `kunden`
--
ALTER TABLE `kunden`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT;

--
-- Constraints der exportierten Tabellen
--

--
-- Constraints der Tabelle `ausgeliehen`
--
ALTER TABLE `ausgeliehen`
  ADD CONSTRAINT `ausgeliehen_ibfk_1` FOREIGN KEY (`Instrument_FK`) REFERENCES `instrument` (`ID`),
  ADD CONSTRAINT `ausgeliehen_ibfk_2` FOREIGN KEY (`Kunden_FK`) REFERENCES `kunden` (`ID`);

--
-- Constraints der Tabelle `instrument`
--
ALTER TABLE `instrument`
  ADD CONSTRAINT `instrument_ibfk_1` FOREIGN KEY (`HerstellerFK`) REFERENCES `hersteller` (`ID`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
