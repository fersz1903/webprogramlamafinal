-- phpMyAdmin SQL Dump
-- version 5.1.0
-- https://www.phpmyadmin.net/
--
-- Anamakine: mysql6008.site4now.net
-- Üretim Zamanı: 09 Haz 2023, 08:28:47
-- Sunucu sürümü: 8.0.32
-- PHP Sürümü: 8.0.9

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Veritabanı: `db_a9a62c_cafedb`
--

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `cm_category`
--

CREATE TABLE `cm_category` (
  `Id` int NOT NULL,
  `name` varchar(100) COLLATE utf8mb4_turkish_ci NOT NULL,
  `imagePath` text COLLATE utf8mb4_turkish_ci
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_turkish_ci;

--
-- Tablo döküm verisi `cm_category`
--

INSERT INTO `cm_category` (`Id`, `name`, `imagePath`) VALUES
(10, 'Soğuk İçecekler', '../images/soğukİçecek.jpg'),
(11, 'Sıcak İçecekler', '../images/file.png'),
(12, 'Pizzalar', '../images/pizza.jpg'),
(13, 'Burgerler', '../images/hamburger.jpg'),
(14, 'Salatalar', '../images/mevsim-salatasi-tarifi.jpg'),
(15, 'Şerbetli Tatlılar', '../images/kemalpaiai-BUiC_cover.webp'),
(16, 'Tatlılar', '../images/tatlılar.jpg');

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `cm_menu`
--

CREATE TABLE `cm_menu` (
  `Id` int NOT NULL,
  `categoryId` int NOT NULL,
  `name` text COLLATE utf8mb4_turkish_ci NOT NULL,
  `price` decimal(10,0) NOT NULL,
  `imagePath` text COLLATE utf8mb4_turkish_ci
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_turkish_ci;

--
-- Tablo döküm verisi `cm_menu`
--

INSERT INTO `cm_menu` (`Id`, `categoryId`, `name`, `price`, `imagePath`) VALUES
(14, 10, 'Coca cola', '16', '../images/coca-cola330.jpg'),
(15, 10, 'Fanta', '16', '../images/fanta-330.jpg'),
(16, 10, 'Sprite', '14', '../images/sprite.webp'),
(17, 10, 'Ayran', '8', '../images/46054715-8a2faf-1650x1650.jpg'),
(18, 10, 'Şalgam', '8', '../images/1_org_zoom.webp'),
(19, 10, 'Soğuk Çay', '10', '../images/08059549-366ead-1650x1650.jpg'),
(20, 11, 'Çay', '15', '../images/içecek.jpg'),
(21, 11, 'Türk Kahvesi', '25', '../images/What-is-Turkish-Coffee-Thumbnail_455x455.webp'),
(22, 10, 'Çikolatalı Milkshake', '35', '../images/milkshake.webp'),
(23, 10, 'Çilekli Milkshake', '35', '../images/çilekli milkshake1.webp'),
(24, 11, 'Oralet Çeşitleri', '12', '../images/oralet.jpg'),
(25, 11, 'Espresso', '45', '../images/espresso.webp'),
(26, 11, 'White Chocolate Mocha', '55', '../images/white chocolate mocha.jpg'),
(27, 11, 'Macchiato', '47', '../images/macchiato.jpg'),
(28, 11, 'Americano', '47', '../images/americano.webp'),
(29, 11, 'Filtre Kahve', '52', '../images/filtre kahve.jpg'),
(30, 11, 'Aromalı Sıcak Çikolata', '55', '../images/aromalı sıcak çikolata.jpg'),
(31, 12, 'Bizim Bahçeden', '120', '../images/Bizim Bahçeden.jpg'),
(32, 12, 'Margarita', '120', '../images/Margarita.jpg'),
(33, 12, 'Tavuklu Mantarlı', '130', '../images/Tavuklu Mantarlı.jpg'),
(34, 12, 'Üç Peynirli', '120', '../images/3 Peynirli.jpg'),
(35, 12, 'Meksika', '135', '../images/Meksika.jpg'),
(36, 12, 'Karışık', '135', '../images/Karışık.jpg'),
(37, 13, 'Hamburger', '95', '../images/Hamburger1.jpg'),
(38, 13, 'Cheesburger', '105', '../images/Cheesburger.jpg'),
(39, 14, 'Sezar Salata', '110', '../images/Sezar Salata.jpg'),
(40, 14, 'Izgara Tavuk Salata', '120', '../images/Izgara Tavuk Salata.jpg'),
(41, 14, 'Ton Balıklı Salata', '120', '../images/Ton Balıklı Salata.jpg'),
(42, 14, 'Akdeniz Salata', '85', '../images/Akdeniz Salata.jpg'),
(43, 15, 'Fıstıklı Baklava', '120', '../images/Baklava.jpg'),
(44, 15, 'Kemalpaşa', '70', '../images/kemalpaşa.jpg'),
(45, 15, 'Kadayıf Dolma', '110', '../images/Kadayıf Dolma.webp'),
(46, 15, 'Midye Baklava', '120', '../images/Midye baklava.jpg'),
(47, 15, 'Havuç Dilimi', '110', '../images/Havuç Dilimi.jpg'),
(48, 15, 'Ekmek Kadayıfı', '90', '../images/Ekmek Kadayıfı.jpg'),
(49, 15, 'Cevizli Baklava', '100', '../images/Cevizli Baklava.jpg'),
(50, 16, 'Fırın Sütlaç', '55', '../images/Fırın Sütlaç.jpg'),
(51, 16, 'magnolia', '50', '../images/Magnolia.jpg'),
(52, 16, 'Tavuk Göğsü', '45', '../images/Tavuk göğsü.webp'),
(54, 16, 'Kazandibi', '40', '../images/Kazandibi.jpg'),
(55, 16, 'Cheescake Çeşitleri', '90', '../images/cheescake.webp'),
(56, 16, 'Profiterol', '50', '../images/profiterol.webp'),
(57, 16, 'Ekler', '50', '../images/ekler.webp');

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `cm_order`
--

CREATE TABLE `cm_order` (
  `Id` int NOT NULL,
  `tableNo` int NOT NULL,
  `name` longtext COLLATE utf8mb4_turkish_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_turkish_ci;

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `cm_song`
--

CREATE TABLE `cm_song` (
  `Id` int NOT NULL,
  `songName` varchar(200) COLLATE utf8mb4_turkish_ci NOT NULL,
  `tableNo` int NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_turkish_ci;

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `cm_user`
--

CREATE TABLE `cm_user` (
  `Id` int NOT NULL,
  `username` varchar(20) COLLATE utf8mb4_turkish_ci NOT NULL,
  `password` tinytext COLLATE utf8mb4_turkish_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_turkish_ci;

--
-- Tablo döküm verisi `cm_user`
--

INSERT INTO `cm_user` (`Id`, `username`, `password`) VALUES
(1, 'admin', '1234');

--
-- Dökümü yapılmış tablolar için indeksler
--

--
-- Tablo için indeksler `cm_category`
--
ALTER TABLE `cm_category`
  ADD PRIMARY KEY (`Id`);

--
-- Tablo için indeksler `cm_menu`
--
ALTER TABLE `cm_menu`
  ADD PRIMARY KEY (`Id`);

--
-- Tablo için indeksler `cm_order`
--
ALTER TABLE `cm_order`
  ADD PRIMARY KEY (`Id`);

--
-- Tablo için indeksler `cm_song`
--
ALTER TABLE `cm_song`
  ADD PRIMARY KEY (`Id`);

--
-- Tablo için indeksler `cm_user`
--
ALTER TABLE `cm_user`
  ADD PRIMARY KEY (`Id`);

--
-- Dökümü yapılmış tablolar için AUTO_INCREMENT değeri
--

--
-- Tablo için AUTO_INCREMENT değeri `cm_category`
--
ALTER TABLE `cm_category`
  MODIFY `Id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=17;

--
-- Tablo için AUTO_INCREMENT değeri `cm_menu`
--
ALTER TABLE `cm_menu`
  MODIFY `Id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=58;

--
-- Tablo için AUTO_INCREMENT değeri `cm_order`
--
ALTER TABLE `cm_order`
  MODIFY `Id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=12;

--
-- Tablo için AUTO_INCREMENT değeri `cm_song`
--
ALTER TABLE `cm_song`
  MODIFY `Id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=10;

--
-- Tablo için AUTO_INCREMENT değeri `cm_user`
--
ALTER TABLE `cm_user`
  MODIFY `Id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
