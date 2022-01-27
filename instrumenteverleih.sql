-- phpMyAdmin SQL Dump
-- version 4.0.4.2
-- http://www.phpmyadmin.net
--
-- Host: localhost
-- Erstellungszeit: 27. Jan 2022 um 17:49
-- Server Version: 5.6.13
-- PHP-Version: 5.4.17

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Datenbank: `instrumenteverleih`
--
CREATE DATABASE IF NOT EXISTS `instrumenteverleih` DEFAULT CHARACTER SET latin1 COLLATE latin1_swedish_ci;
USE `instrumenteverleih`;

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `kunden`
--

CREATE TABLE IF NOT EXISTS `kunden` (
  `ID` int(12) NOT NULL AUTO_INCREMENT,
  `Name` varchar(255) NOT NULL,
  `Vorname` varchar(255) NOT NULL,
  `Ort` varchar(12) NOT NULL,
  `strasse` varchar(12) NOT NULL,
  `hausnummer` varchar(255) NOT NULL,
  `Telefonnummer` int(255) NOT NULL,
  PRIMARY KEY (`ID`),
  UNIQUE KEY `ID` (`ID`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=5 ;

--
-- Daten für Tabelle `kunden`
--

INSERT INTO `kunden` (`ID`, `Name`, `Vorname`, `Ort`, `strasse`, `hausnummer`, `Telefonnummer`) VALUES
(1, 'mustermann', 'max', 'Mechernich', 'strasse', 'hausnummer', 2147483647),
(2, 'Super hero squad', 'Metro City', 'fefwfs', 'Super tower', 'Super tower', 0),
(4, 'Super hero squad', 'Metro City', 'fefwfs', 'Super tower', 'Super tower', 0);

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
