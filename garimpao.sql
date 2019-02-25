-- --------------------------------------------------------
-- Servidor:                     127.0.0.1
-- Versão do servidor:           5.5.60-log - MySQL Community Server (GPL)
-- OS do Servidor:               Win32
-- HeidiSQL Versão:              9.5.0.5196
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;


-- Copiando estrutura do banco de dados para garimpao
CREATE DATABASE IF NOT EXISTS `garimpao` /*!40100 DEFAULT CHARACTER SET utf8 */;
USE `garimpao`;

-- Copiando estrutura para tabela garimpao.cat_categorias
CREATE TABLE IF NOT EXISTS `cat_categorias` (
  `cat_codigo` int(11) NOT NULL AUTO_INCREMENT,
  `cat_nome` varchar(20) NOT NULL,
  `cat_figura` varchar(255) DEFAULT NULL,
  `est_codigo` int(11) NOT NULL,
  PRIMARY KEY (`cat_codigo`),
  KEY `est_codigo` (`est_codigo`),
  CONSTRAINT `cat_categorias_ibfk_1` FOREIGN KEY (`est_codigo`) REFERENCES `est_estilos` (`est_codigo`)
) ENGINE=InnoDB AUTO_INCREMENT=74 DEFAULT CHARSET=utf8;

-- Copiando dados para a tabela garimpao.cat_categorias: ~56 rows (aproximadamente)
DELETE FROM `cat_categorias`;
/*!40000 ALTER TABLE `cat_categorias` DISABLE KEYS */;
INSERT INTO `cat_categorias` (`cat_codigo`, `cat_nome`, `cat_figura`, `est_codigo`) VALUES
	(18, 'Acessórios', NULL, 21),
	(19, 'Roupas', NULL, 21),
	(20, 'Beleza', NULL, 21),
	(21, 'Calçados', NULL, 21),
	(22, 'Bolsas', NULL, 21),
	(23, 'Lingerie', NULL, 21),
	(24, 'Casamento', NULL, 21),
	(25, 'Acessórios', NULL, 17),
	(26, 'Roupas', NULL, 17),
	(27, 'Beleza', NULL, 17),
	(28, 'Calçados', NULL, 17),
	(29, 'Bolsas', NULL, 17),
	(30, 'Lingerie', NULL, 17),
	(31, 'Casamento', NULL, 17),
	(32, 'Acessórios', NULL, 20),
	(33, 'Roupas', NULL, 20),
	(34, 'Beleza', NULL, 20),
	(35, 'Calçados', NULL, 20),
	(36, 'Bolsas', NULL, 20),
	(37, 'Lingerie', NULL, 20),
	(38, 'Casamento', NULL, 20),
	(39, 'Acessórios', NULL, 18),
	(40, 'Roupas', NULL, 18),
	(41, 'Beleza', NULL, 18),
	(42, 'Calçados', NULL, 18),
	(43, 'Bolsas', NULL, 18),
	(44, 'Lingerie', NULL, 18),
	(45, 'Casamento', NULL, 18),
	(46, 'Acessórios', NULL, 23),
	(47, 'Roupas', NULL, 23),
	(48, 'Beleza', NULL, 23),
	(49, 'Calçados', NULL, 23),
	(50, 'Bolsas', NULL, 23),
	(51, 'Lingerie', NULL, 23),
	(52, 'Casamento', NULL, 23),
	(53, 'Acessórios', NULL, 22),
	(54, 'Roupas', NULL, 22),
	(55, 'Beleza', NULL, 22),
	(56, 'Calçados', NULL, 22),
	(57, 'Bolsas', NULL, 22),
	(58, 'Lingerie', NULL, 22),
	(59, 'Casamento', NULL, 22),
	(60, 'Acessórios', NULL, 19),
	(61, 'Roupas', NULL, 19),
	(62, 'Beleza', NULL, 19),
	(63, 'Calçados', NULL, 19),
	(64, 'Bolsas', NULL, 19),
	(65, 'Lingerie', NULL, 19),
	(66, 'Casamento', NULL, 19),
	(67, 'Acessórios', NULL, 24),
	(68, 'Roupas', NULL, 24),
	(69, 'Beleza', NULL, 24),
	(70, 'Calçados', NULL, 24),
	(71, 'Bolsas', NULL, 24),
	(72, 'Lingerie', NULL, 24),
	(73, 'Casamento', NULL, 24);
/*!40000 ALTER TABLE `cat_categorias` ENABLE KEYS */;

-- Copiando estrutura para tabela garimpao.com_compras
CREATE TABLE IF NOT EXISTS `com_compras` (
  `com_codigo` int(11) NOT NULL AUTO_INCREMENT,
  `com_data` date NOT NULL,
  `com_valor_total` double NOT NULL,
  `com_status` tinyint(4) NOT NULL,
  `usu_cpf_cnpj` char(20) NOT NULL,
  `pro_codigo` int(11) NOT NULL,
  PRIMARY KEY (`com_codigo`),
  KEY `usu_cpf_cnpj` (`usu_cpf_cnpj`),
  KEY `pro_codigo` (`pro_codigo`),
  CONSTRAINT `com_compras_ibfk_1` FOREIGN KEY (`usu_cpf_cnpj`) REFERENCES `usu_usuarios` (`usu_cpf_cnpj`),
  CONSTRAINT `pro_codigo` FOREIGN KEY (`pro_codigo`) REFERENCES `pro_produtos` (`pro_codigo`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;

-- Copiando dados para a tabela garimpao.com_compras: ~1 rows (aproximadamente)
DELETE FROM `com_compras`;
/*!40000 ALTER TABLE `com_compras` DISABLE KEYS */;
INSERT INTO `com_compras` (`com_codigo`, `com_data`, `com_valor_total`, `com_status`, `usu_cpf_cnpj`, `pro_codigo`) VALUES
	(1, '2018-06-18', 0, 0, '436.606.008-65', 106);
/*!40000 ALTER TABLE `com_compras` ENABLE KEYS */;

-- Copiando estrutura para tabela garimpao.cop_cores_produtos
CREATE TABLE IF NOT EXISTS `cop_cores_produtos` (
  `cor_cod` int(11) NOT NULL,
  `pro_codigo` int(11) NOT NULL,
  PRIMARY KEY (`cor_cod`,`pro_codigo`),
  KEY `pro_codigo` (`pro_codigo`),
  CONSTRAINT `cop_cores_produtos_ibfk_1` FOREIGN KEY (`cor_cod`) REFERENCES `cor_cores` (`cor_codigo`),
  CONSTRAINT `cop_cores_produtos_ibfk_2` FOREIGN KEY (`pro_codigo`) REFERENCES `pro_produtos` (`pro_codigo`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- Copiando dados para a tabela garimpao.cop_cores_produtos: ~38 rows (aproximadamente)
DELETE FROM `cop_cores_produtos`;
/*!40000 ALTER TABLE `cop_cores_produtos` DISABLE KEYS */;
INSERT INTO `cop_cores_produtos` (`cor_cod`, `pro_codigo`) VALUES
	(2, 105),
	(10, 106),
	(4, 108),
	(2, 109),
	(3, 109),
	(4, 109),
	(10, 109),
	(2, 110),
	(6, 110),
	(11, 111),
	(12, 111),
	(1, 112),
	(2, 112),
	(3, 112),
	(6, 112),
	(1, 113),
	(2, 113),
	(3, 113),
	(6, 113),
	(2, 114),
	(1, 115),
	(3, 115),
	(6, 115),
	(2, 116),
	(1, 117),
	(2, 117),
	(2, 118),
	(2, 119),
	(2, 120),
	(2, 121),
	(9, 121),
	(2, 122),
	(11, 123),
	(1, 124),
	(14, 124),
	(4, 125),
	(2, 126),
	(4, 126);
/*!40000 ALTER TABLE `cop_cores_produtos` ENABLE KEYS */;

-- Copiando estrutura para tabela garimpao.cor_cores
CREATE TABLE IF NOT EXISTS `cor_cores` (
  `cor_codigo` int(11) NOT NULL AUTO_INCREMENT,
  `cor_nome` varchar(45) NOT NULL,
  `cor_imagem` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`cor_codigo`)
) ENGINE=InnoDB AUTO_INCREMENT=16 DEFAULT CHARSET=utf8;

-- Copiando dados para a tabela garimpao.cor_cores: ~15 rows (aproximadamente)
DELETE FROM `cor_cores`;
/*!40000 ALTER TABLE `cor_cores` DISABLE KEYS */;
INSERT INTO `cor_cores` (`cor_codigo`, `cor_nome`, `cor_imagem`) VALUES
	(1, 'branco', '\\CoresProdutos\\branco.png'),
	(2, 'Preto', '\\CoresProdutos\\preto.jpg'),
	(3, 'Azul', '\\CoresProdutos\\azul.jpg'),
	(4, 'Amarelo', '\\CoresProdutos\\amarelo.jpg'),
	(5, 'Roxo', '\\CoresProdutos\\roxo.jpg'),
	(6, 'Vermelho', '\\CoresProdutos\\vermelho.jpg'),
	(7, 'Cinza', '\\CoresProdutos\\cinza.jpg'),
	(8, 'Bege', '\\CoresProdutos\\bege.jpg'),
	(9, 'Marrom', '\\CoresProdutos\\marrom.png'),
	(10, 'Verde', '\\CoresProdutos\\verde.png'),
	(11, 'Dourado', '\\CoresProdutos\\dourado.jpg'),
	(12, 'Laranja', '\\CoresProdutos\\laranja.jpg'),
	(13, 'Prata', '\\CoresProdutos\\prata.jpg'),
	(14, 'Rosa', '\\CoresProdutos\\rosa.jpg'),
	(15, 'Vinho', '\\CoresProdutos\\vinho.jpg');
/*!40000 ALTER TABLE `cor_cores` ENABLE KEYS */;

-- Copiando estrutura para tabela garimpao.den_denuncias
CREATE TABLE IF NOT EXISTS `den_denuncias` (
  `den_codigo` int(11) NOT NULL AUTO_INCREMENT,
  `den_opcao` int(11) NOT NULL,
  `den_tipo` int(11) NOT NULL,
  `usu_cpf_cnpj` char(20) NOT NULL,
  `pro_codigo` int(11) NOT NULL,
  PRIMARY KEY (`den_codigo`),
  KEY `usu_cpf` (`usu_cpf_cnpj`),
  KEY `pro_codigo` (`pro_codigo`),
  CONSTRAINT `den_denuncias_ibfk_1` FOREIGN KEY (`usu_cpf_cnpj`) REFERENCES `usu_usuarios` (`usu_cpf_cnpj`),
  CONSTRAINT `den_denuncias_ibfk_2` FOREIGN KEY (`pro_codigo`) REFERENCES `pro_produtos` (`pro_codigo`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- Copiando dados para a tabela garimpao.den_denuncias: ~0 rows (aproximadamente)
DELETE FROM `den_denuncias`;
/*!40000 ALTER TABLE `den_denuncias` DISABLE KEYS */;
/*!40000 ALTER TABLE `den_denuncias` ENABLE KEYS */;

-- Copiando estrutura para tabela garimpao.end_enderecos
CREATE TABLE IF NOT EXISTS `end_enderecos` (
  `end_codigo` int(11) NOT NULL AUTO_INCREMENT,
  `end_cep` varchar(10) NOT NULL,
  `end_estado` varchar(40) NOT NULL,
  `end_cidade` varchar(80) NOT NULL,
  `end_bairro` varchar(80) NOT NULL,
  `end_endereco` varchar(255) NOT NULL,
  `end_referencia` varchar(255) DEFAULT NULL,
  `end_numero` int(11) NOT NULL,
  `usu_cpf_cnpj` char(20) NOT NULL,
  PRIMARY KEY (`end_codigo`),
  KEY `fk_end_enderecos_usu_usuarios1_idx` (`usu_cpf_cnpj`),
  CONSTRAINT `fk_end_enderecos_usu_usuarios1` FOREIGN KEY (`usu_cpf_cnpj`) REFERENCES `usu_usuarios` (`usu_cpf_cnpj`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=246 DEFAULT CHARSET=utf8;

-- Copiando dados para a tabela garimpao.end_enderecos: ~14 rows (aproximadamente)
DELETE FROM `end_enderecos`;
/*!40000 ALTER TABLE `end_enderecos` DISABLE KEYS */;
INSERT INTO `end_enderecos` (`end_codigo`, `end_cep`, `end_estado`, `end_cidade`, `end_bairro`, `end_endereco`, `end_referencia`, `end_numero`, `usu_cpf_cnpj`) VALUES
	(220, '12518-110', 'SP', 'Guaratinguetá', 'Parque do Sol', 'Rua Antônio Galhardo', '', 6565, '756.475.445-11'),
	(221, '12518-110', 'SP', 'Guaratinguetá', 'Parque do Sol', 'Rua Antônio Galhardo', '', 556, '445.687.874-51'),
	(222, '02022-021', 'SP', 'São Paulo', 'Santana', 'Avenida Braz Leme', '', 12, '457.897.465-13'),
	(224, '20941-001', 'RJ', 'Rio de Janeiro', 'São Cristóvão', 'Rua Figueira de Melo', '', 11, '216.561.235-55'),
	(226, '12518-410', 'SP', 'Guaratinguetá', 'Jardim Esperança', 'Viela Carlos Alberto Vieira', '', 2345, '111.256.734-54'),
	(227, '12518-110', 'SP', 'Guaratinguetá', 'Parque do Sol', 'Rua Antônio Galhardo', '', 55, '217.832.455-52'),
	(228, '31210-030', 'MG', 'Belo Horizonte', 'Lagoinha', 'Rua Itapecerica', '', 665, '155.477.841-11'),
	(231, '40391-376', 'BA', 'Salvador', 'São Caetano', 'Rua José Tibério', '', 112, '126.782.342-31'),
	(232, '90035-030', 'RS', 'Porto Alegre', 'Floresta', 'Rua Doutor Barros Cassal', '', 5, '125.661.223-55'),
	(233, '12518-110', 'SP', 'Guaratinguetá', 'Parque do Sol', 'Rua Antônio Galhardo', '', 22, '1'),
	(236, '12509-060', 'SP', 'Guaratinguetá', 'Parque São Francisco', 'Rua Doutor Fernando José Almeida Mileo', 'casa', 47, '475.878.548-0'),
	(237, '12518-110', 'SP', 'Guaratinguetá', 'Parque do Sol', 'Rua Antônio Galhardo', '', 65, '121.734.511-11'),
	(240, '12518-110', 'SP', 'Guaratinguetá', 'Parque do Sol', 'Rua Antônio Galhardo', '', 11, '436.606.008-65'),
	(245, '05012-010', 'SP', 'São Paulo', 'Perdizes', 'Rua Ministro Gastão Mesquita', '', 122, '436.606.008-65');
/*!40000 ALTER TABLE `end_enderecos` ENABLE KEYS */;

-- Copiando estrutura para tabela garimpao.enp_envio_produtos
CREATE TABLE IF NOT EXISTS `enp_envio_produtos` (
  `pro_codigo` int(11) NOT NULL,
  `env_codigo` int(11) NOT NULL,
  PRIMARY KEY (`pro_codigo`,`env_codigo`),
  KEY `env_codigo` (`env_codigo`),
  CONSTRAINT `enp_envio_produtos_ibfk_1` FOREIGN KEY (`pro_codigo`) REFERENCES `pro_produtos` (`pro_codigo`),
  CONSTRAINT `enp_envio_produtos_ibfk_2` FOREIGN KEY (`env_codigo`) REFERENCES `env_formas_envios` (`env_codigo`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- Copiando dados para a tabela garimpao.enp_envio_produtos: ~26 rows (aproximadamente)
DELETE FROM `enp_envio_produtos`;
/*!40000 ALTER TABLE `enp_envio_produtos` DISABLE KEYS */;
INSERT INTO `enp_envio_produtos` (`pro_codigo`, `env_codigo`) VALUES
	(105, 1),
	(106, 1),
	(108, 1),
	(109, 1),
	(110, 1),
	(111, 1),
	(112, 1),
	(113, 1),
	(114, 1),
	(115, 1),
	(116, 1),
	(117, 1),
	(118, 1),
	(119, 1),
	(120, 1),
	(121, 1),
	(122, 1),
	(123, 1),
	(124, 1),
	(125, 1),
	(126, 1),
	(112, 2),
	(113, 2),
	(123, 2),
	(124, 2),
	(124, 3);
/*!40000 ALTER TABLE `enp_envio_produtos` ENABLE KEYS */;

-- Copiando estrutura para tabela garimpao.env_formas_envios
CREATE TABLE IF NOT EXISTS `env_formas_envios` (
  `env_codigo` int(11) NOT NULL AUTO_INCREMENT,
  `env_nome` varchar(45) NOT NULL,
  PRIMARY KEY (`env_codigo`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;

-- Copiando dados para a tabela garimpao.env_formas_envios: ~3 rows (aproximadamente)
DELETE FROM `env_formas_envios`;
/*!40000 ALTER TABLE `env_formas_envios` DISABLE KEYS */;
INSERT INTO `env_formas_envios` (`env_codigo`, `env_nome`) VALUES
	(1, 'Correios'),
	(2, 'Em mãos'),
	(3, 'Grátis');
/*!40000 ALTER TABLE `env_formas_envios` ENABLE KEYS */;

-- Copiando estrutura para tabela garimpao.est_estilos
CREATE TABLE IF NOT EXISTS `est_estilos` (
  `est_codigo` int(11) NOT NULL AUTO_INCREMENT,
  `est_nome` varchar(20) NOT NULL,
  `est_figura` varchar(255) DEFAULT NULL,
  `usu_cpf_cnpj` char(20) NOT NULL,
  PRIMARY KEY (`est_codigo`),
  KEY `usu_cpf` (`usu_cpf_cnpj`)
) ENGINE=InnoDB AUTO_INCREMENT=25 DEFAULT CHARSET=utf8;

-- Copiando dados para a tabela garimpao.est_estilos: ~8 rows (aproximadamente)
DELETE FROM `est_estilos`;
/*!40000 ALTER TABLE `est_estilos` DISABLE KEYS */;
INSERT INTO `est_estilos` (`est_codigo`, `est_nome`, `est_figura`, `usu_cpf_cnpj`) VALUES
	(17, 'Geek', NULL, '1'),
	(18, 'Nerd', NULL, '1'),
	(19, 'Rock', NULL, '1'),
	(20, 'Hipster', NULL, '1'),
	(21, 'Country', NULL, '1'),
	(22, 'Retrô', NULL, '1'),
	(23, 'Punk', NULL, '1'),
	(24, 'Sexy', NULL, '1');
/*!40000 ALTER TABLE `est_estilos` ENABLE KEYS */;

-- Copiando estrutura para tabela garimpao.fav_favoritos
CREATE TABLE IF NOT EXISTS `fav_favoritos` (
  `usu_cpf` char(20) NOT NULL,
  `pro_codigo` int(11) NOT NULL,
  KEY `pro_codigo` (`pro_codigo`,`usu_cpf`),
  KEY `fav_favoritos_ibfk_1` (`usu_cpf`),
  CONSTRAINT `fav_favoritos_ibfk_1` FOREIGN KEY (`usu_cpf`) REFERENCES `usu_usuarios` (`usu_cpf_cnpj`),
  CONSTRAINT `fav_favoritos_ibfk_2` FOREIGN KEY (`pro_codigo`) REFERENCES `pro_produtos` (`pro_codigo`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- Copiando dados para a tabela garimpao.fav_favoritos: ~7 rows (aproximadamente)
DELETE FROM `fav_favoritos`;
/*!40000 ALTER TABLE `fav_favoritos` DISABLE KEYS */;
INSERT INTO `fav_favoritos` (`usu_cpf`, `pro_codigo`) VALUES
	('217.832.455-52', 105),
	('217.832.455-52', 106),
	('457.897.465-13', 106),
	('217.832.455-52', 108),
	('436.606.008-65', 108),
	('436.606.008-65', 113),
	('436.606.008-65', 116);
/*!40000 ALTER TABLE `fav_favoritos` ENABLE KEYS */;

-- Copiando estrutura para tabela garimpao.for_forma_pagamentos
CREATE TABLE IF NOT EXISTS `for_forma_pagamentos` (
  `for_codigo` int(11) NOT NULL AUTO_INCREMENT,
  `for_pagamento` varchar(45) NOT NULL,
  PRIMARY KEY (`for_codigo`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- Copiando dados para a tabela garimpao.for_forma_pagamentos: ~0 rows (aproximadamente)
DELETE FROM `for_forma_pagamentos`;
/*!40000 ALTER TABLE `for_forma_pagamentos` DISABLE KEYS */;
/*!40000 ALTER TABLE `for_forma_pagamentos` ENABLE KEYS */;

-- Copiando estrutura para tabela garimpao.fot_fotos
CREATE TABLE IF NOT EXISTS `fot_fotos` (
  `fot_codigo` int(11) NOT NULL AUTO_INCREMENT,
  `fot_url` varchar(255) NOT NULL,
  `pro_codigo` int(11) NOT NULL,
  PRIMARY KEY (`fot_codigo`),
  KEY `pro_codigo` (`pro_codigo`),
  CONSTRAINT `fot_fotos_ibfk_1` FOREIGN KEY (`pro_codigo`) REFERENCES `pro_produtos` (`pro_codigo`)
) ENGINE=InnoDB AUTO_INCREMENT=522 DEFAULT CHARSET=utf8;

-- Copiando dados para a tabela garimpao.fot_fotos: ~45 rows (aproximadamente)
DELETE FROM `fot_fotos`;
/*!40000 ALTER TABLE `fot_fotos` DISABLE KEYS */;
INSERT INTO `fot_fotos` (`fot_codigo`, `fot_url`, `pro_codigo`) VALUES
	(103, '\\Fotos\\Produtos\\250520183104862.jpg', 105),
	(104, '\\Fotos\\Produtos\\250520183107848.jpg', 105),
	(105, '\\Fotos\\Produtos\\250520183107934.jpg', 105),
	(106, '\\Fotos\\Produtos\\250520183929876.jpg', 106),
	(107, '\\Fotos\\Produtos\\250520183929939.jpg', 106),
	(108, '\\Fotos\\Produtos\\250520183929976.jpg', 106),
	(113, '\\Fotos\\Produtos\\250520185816135.jpg', 108),
	(114, '\\Fotos\\Produtos\\250520185816178.jpg', 108),
	(115, '\\Fotos\\Produtos\\250520182957059.jpg', 109),
	(116, '\\Fotos\\Produtos\\250520183003783.jpg', 109),
	(117, '\\Fotos\\Produtos\\250520183004833.jpg', 109),
	(118, '\\Fotos\\Produtos\\250520183005824.jpg', 109),
	(119, '\\Fotos\\Produtos\\250520183647057.jpg', 110),
	(150, '\\Fotos\\Produtos\\260520185355751.jpg', 112),
	(151, '\\Fotos\\Produtos\\260520185357739.jpg', 112),
	(152, '\\Fotos\\Produtos\\260520183231122.jpg', 113),
	(153, '\\Fotos\\Produtos\\260520183229117.jpg', 113),
	(154, '\\Fotos\\Produtos\\260520184611551.jpg', 114),
	(155, '\\Fotos\\Produtos\\260520184611639.jpg', 114),
	(156, '\\Fotos\\Produtos\\260520184158532.jpg', 115),
	(157, '\\Fotos\\Produtos\\260520184158584.jpg', 115),
	(158, '\\Fotos\\Produtos\\260520182233425.jpg', 116),
	(159, '\\Fotos\\Produtos\\260520182233496.jpg', 116),
	(160, '\\Fotos\\Produtos\\260520183731895.jpg', 117),
	(161, '\\Fotos\\Produtos\\260520183733910.jpg', 117),
	(162, '\\Fotos\\Produtos\\260520184913255.jpg', 118),
	(163, '\\Fotos\\Produtos\\260520184915333.jpg', 118),
	(164, '\\Fotos\\Produtos\\260520184916372.jpg', 118),
	(165, '\\Fotos\\Produtos\\260520183642386.jpg', 119),
	(166, '\\Fotos\\Produtos\\260520183642272.jpg', 119),
	(167, '\\Fotos\\Produtos\\260520184037149.jpg', 120),
	(168, '\\Fotos\\Produtos\\260520184037216.jpg', 120),
	(169, '\\Fotos\\Produtos\\260520184037312.jpg', 120),
	(170, '\\Fotos\\Produtos\\260520184412287.jpg', 121),
	(171, '\\Fotos\\Produtos\\260520185357661.jpg', 122),
	(390, '\\Fotos\\Produtos\\270520180141583.jpg', 123),
	(391, '\\Fotos\\Produtos\\270520180144450.jpg', 123),
	(392, '\\Fotos\\Produtos\\270520180743716.jpg', 124),
	(393, '\\Fotos\\Produtos\\270520180743775.jpg', 124),
	(394, '\\Fotos\\Produtos\\270520180743843.jpg', 124),
	(514, '\\Fotos\\Produtos\\110620184834777.jpg', 125),
	(518, '\\Fotos\\Produtos\\180620183058670.png', 111),
	(519, '\\Fotos\\Produtos\\190620181402293.jpg', 126),
	(520, '\\Fotos\\Produtos\\190620181409105.jpg', 126),
	(521, '\\Fotos\\Produtos\\190620181418056.jpg', 126);
/*!40000 ALTER TABLE `fot_fotos` ENABLE KEYS */;

-- Copiando estrutura para tabela garimpao.fpp_forma_produtos
CREATE TABLE IF NOT EXISTS `fpp_forma_produtos` (
  `for_codigo` int(11) NOT NULL,
  `pro_codigo` int(11) NOT NULL,
  PRIMARY KEY (`for_codigo`,`pro_codigo`),
  KEY `pro_codigo` (`pro_codigo`),
  CONSTRAINT `fpp_forma_produtos_ibfk_1` FOREIGN KEY (`for_codigo`) REFERENCES `for_forma_pagamentos` (`for_codigo`),
  CONSTRAINT `fpp_forma_produtos_ibfk_2` FOREIGN KEY (`pro_codigo`) REFERENCES `pro_produtos` (`pro_codigo`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- Copiando dados para a tabela garimpao.fpp_forma_produtos: ~0 rows (aproximadamente)
DELETE FROM `fpp_forma_produtos`;
/*!40000 ALTER TABLE `fpp_forma_produtos` DISABLE KEYS */;
/*!40000 ALTER TABLE `fpp_forma_produtos` ENABLE KEYS */;

-- Copiando estrutura para tabela garimpao.ite_itens
CREATE TABLE IF NOT EXISTS `ite_itens` (
  `pro_codigo` int(11) NOT NULL,
  `com_codigo` int(11) NOT NULL,
  `ite_quantidade` int(11) NOT NULL,
  PRIMARY KEY (`pro_codigo`,`com_codigo`),
  KEY `com_codigo` (`com_codigo`),
  CONSTRAINT `ite_itens_ibfk_1` FOREIGN KEY (`pro_codigo`) REFERENCES `pro_produtos` (`pro_codigo`),
  CONSTRAINT `ite_itens_ibfk_2` FOREIGN KEY (`com_codigo`) REFERENCES `com_compras` (`com_codigo`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- Copiando dados para a tabela garimpao.ite_itens: ~0 rows (aproximadamente)
DELETE FROM `ite_itens`;
/*!40000 ALTER TABLE `ite_itens` DISABLE KEYS */;
/*!40000 ALTER TABLE `ite_itens` ENABLE KEYS */;

-- Copiando estrutura para tabela garimpao.mar_marcas
CREATE TABLE IF NOT EXISTS `mar_marcas` (
  `mar_codigo` int(11) NOT NULL AUTO_INCREMENT,
  `mar_nome` varchar(40) NOT NULL,
  `mar_logo` varchar(255) DEFAULT NULL,
  `mar_status` tinyint(1) DEFAULT NULL,
  `usu_cpf_cnpj` char(20) NOT NULL,
  PRIMARY KEY (`mar_codigo`),
  KEY `usu_cpf` (`usu_cpf_cnpj`),
  CONSTRAINT `mar_marcas_ibfk_1` FOREIGN KEY (`usu_cpf_cnpj`) REFERENCES `usu_usuarios` (`usu_cpf_cnpj`)
) ENGINE=InnoDB AUTO_INCREMENT=63 DEFAULT CHARSET=utf8;

-- Copiando dados para a tabela garimpao.mar_marcas: ~30 rows (aproximadamente)
DELETE FROM `mar_marcas`;
/*!40000 ALTER TABLE `mar_marcas` DISABLE KEYS */;
INSERT INTO `mar_marcas` (`mar_codigo`, `mar_nome`, `mar_logo`, `mar_status`, `usu_cpf_cnpj`) VALUES
	(33, 'Adidas', NULL, NULL, '1'),
	(34, 'Marca Própria', NULL, NULL, '1'),
	(35, 'Hering', NULL, NULL, '1'),
	(36, 'Azzaro', NULL, NULL, '1'),
	(37, 'L\'Oreal Paris', NULL, NULL, '1'),
	(38, 'Love Secret', NULL, NULL, '1'),
	(39, 'Colcci', NULL, NULL, '1'),
	(40, 'Agua Doce', NULL, NULL, '1'),
	(41, 'Asics', NULL, NULL, '1'),
	(42, 'Calvin Klein', NULL, NULL, '1'),
	(43, 'DC Comics', NULL, NULL, '1'),
	(44, 'Dakar', NULL, NULL, '1'),
	(45, 'Element', NULL, NULL, '1'),
	(46, 'Geek10', NULL, NULL, '1'),
	(47, 'Habana', NULL, NULL, '1'),
	(48, 'Hang Loose', NULL, NULL, '1'),
	(49, 'New Era', NULL, NULL, '1'),
	(50, 'Nike', NULL, NULL, '1'),
	(51, 'New Girls', NULL, NULL, '1'),
	(52, 'Oakley', NULL, NULL, '1'),
	(53, 'Mundo Rock', NULL, NULL, '1'),
	(54, 'Sem marca', NULL, NULL, '436.606.008-65'),
	(55, 'Marisa', NULL, NULL, '756.475.445-11'),
	(56, 'All Star', NULL, NULL, '445.687.874-51'),
	(57, 'Vulpe', NULL, NULL, '457.897.465-13'),
	(58, 'JC Decore', NULL, NULL, '216.561.235-55'),
	(59, 'Darth Vader', NULL, NULL, '155.477.841-11'),
	(60, 'Slipknot', NULL, NULL, '126.782.342-31'),
	(61, 'Bomber', NULL, NULL, '126.782.342-31'),
	(62, 'tenisjuca', NULL, NULL, '475.878.548-0');
/*!40000 ALTER TABLE `mar_marcas` ENABLE KEYS */;

-- Copiando estrutura para tabela garimpao.men_mensagens
CREATE TABLE IF NOT EXISTS `men_mensagens` (
  `men_codigo` int(11) NOT NULL AUTO_INCREMENT,
  `men_conteudo` varchar(255) NOT NULL,
  `men_moderacao_status` char(1) DEFAULT NULL,
  `men_arquivada` tinyint(1) DEFAULT NULL,
  `men_data` datetime DEFAULT NULL,
  `men_lida` tinyint(1) DEFAULT NULL,
  `usu_cpf_cnpj` char(20) DEFAULT NULL,
  `pro_codigo` int(11) DEFAULT NULL,
  `tme_codigo` int(11) DEFAULT NULL,
  `men_pergunta_codigo` char(20) DEFAULT NULL,
  `men_cpf_pergunta` char(20) DEFAULT NULL,
  `men_respondida` tinyint(4) DEFAULT NULL,
  `men_visivel` tinyint(4) DEFAULT NULL,
  PRIMARY KEY (`men_codigo`),
  KEY `usu_cpf` (`usu_cpf_cnpj`),
  KEY `pro_codigo` (`pro_codigo`),
  KEY `tme_codigo` (`tme_codigo`),
  CONSTRAINT `men_mensagens_ibfk_1` FOREIGN KEY (`usu_cpf_cnpj`) REFERENCES `usu_usuarios` (`usu_cpf_cnpj`),
  CONSTRAINT `men_mensagens_ibfk_2` FOREIGN KEY (`pro_codigo`) REFERENCES `pro_produtos` (`pro_codigo`),
  CONSTRAINT `men_mensagens_ibfk_3` FOREIGN KEY (`tme_codigo`) REFERENCES `tme_tipo_mensagens` (`tme_codigo`)
) ENGINE=InnoDB AUTO_INCREMENT=384 DEFAULT CHARSET=utf8;

-- Copiando dados para a tabela garimpao.men_mensagens: ~301 rows (aproximadamente)
DELETE FROM `men_mensagens`;
/*!40000 ALTER TABLE `men_mensagens` DISABLE KEYS */;
INSERT INTO `men_mensagens` (`men_codigo`, `men_conteudo`, `men_moderacao_status`, `men_arquivada`, `men_data`, `men_lida`, `usu_cpf_cnpj`, `pro_codigo`, `tme_codigo`, `men_pergunta_codigo`, `men_cpf_pergunta`, `men_respondida`, `men_visivel`) VALUES
	(65, 'Seja muito bem-vindo Sr(a) gabriel de paula  ao Garimpo, aqui você pode vender seus produtos e também comprar novos produtos', NULL, NULL, '2018-05-25 20:17:11', 1, '436.606.008-65', NULL, 1, NULL, NULL, NULL, 1),
	(66, 'Você finalizou o cadastro Sr(a)  no Garimpo, agora você pode comprar e vender', NULL, NULL, '2018-05-25 20:18:10', 1, '436.606.008-65', NULL, 1, NULL, NULL, NULL, 1),
	(70, 'Olá sr(a) gabriel de paula  você efetuou o cadastro do seu produto Camisa do Guns N\' Roses, agora é só aguardar os administradores aceitarem para que seu produto fique ativo. seu produto cadastrado foi um(a) Camisa do Guns N\' Rosescom1 unidade(s)', NULL, NULL, '2018-05-25 20:31:08', 1, '436.606.008-65', 105, 1, NULL, NULL, NULL, 1),
	(71, 'Olá sr(a) Administrador, o usuário Administrador inseriu um novo produto no sistema, irá aparecer na página Moderar Produtos, Atenciosamente Garimpo.', NULL, NULL, '2018-05-25 20:31:08', 1, '1', 105, 1, NULL, NULL, NULL, NULL),
	(72, 'Sr(a) gabriel de paula , seu produto foi aprovado no sistema.', NULL, NULL, '2018-05-25 20:31:46', 1, '436.606.008-65', 105, 5, NULL, NULL, NULL, 1),
	(73, 'Olá sr(a) gabriel de paula  você efetuou o cadastro do seu produto geek girly, agora é só aguardar os administradores aceitarem para que seu produto fique ativo. seu produto cadastrado foi um(a) geek girlycom1 unidade(s)', NULL, NULL, '2018-05-25 20:39:30', 1, '436.606.008-65', 106, 1, NULL, NULL, NULL, 1),
	(74, 'Olá sr(a) Administrador, o usuário Administrador inseriu um novo produto no sistema, irá aparecer na página Moderar Produtos, Atenciosamente Garimpo.', NULL, NULL, '2018-05-25 20:39:30', 1, '1', 106, 1, NULL, NULL, NULL, NULL),
	(75, 'Sr(a) gabriel de paula , seu produto foi aprovado no sistema.', NULL, NULL, '2018-05-25 20:39:43', 1, '436.606.008-65', 106, 5, NULL, NULL, NULL, 0),
	(76, 'Seja muito bem-vindo Sr(a) marcelo vidas ao Garimpo, aqui você pode vender seus produtos e também comprar novos produtos', NULL, NULL, '2018-05-25 20:48:16', 1, '756.475.445-11', NULL, 1, NULL, NULL, NULL, 1),
	(77, 'Você finalizou o cadastro Sr(a)  no Garimpo, agora você pode comprar e vender', NULL, NULL, '2018-05-25 20:49:55', 1, '756.475.445-11', NULL, 1, NULL, NULL, NULL, 1),
	(81, 'Olá sr(a) marcelo vidas você efetuou o cadastro do seu produto cropped amarelo geek, agora é só aguardar os administradores aceitarem para que seu produto fique ativo. seu produto cadastrado foi um(a) cropped amarelo geekcom1 unidade(s)', NULL, NULL, '2018-05-25 20:58:16', 1, '756.475.445-11', 108, 1, NULL, NULL, NULL, 1),
	(82, 'Olá sr(a) Administrador, o usuário Administrador inseriu um novo produto no sistema, irá aparecer na página Moderar Produtos, Atenciosamente Garimpo.', NULL, NULL, '2018-05-25 20:58:16', 1, '1', 108, 1, NULL, NULL, NULL, NULL),
	(83, 'Sr(a) marcelo vidas, seu produto foi aprovado no sistema.', NULL, NULL, '2018-05-25 20:58:26', 1, '756.475.445-11', 108, 5, NULL, NULL, NULL, 1),
	(84, 'Seja muito bem-vindo Sr(a) nerd girl ao Garimpo, aqui você pode vender seus produtos e também comprar novos produtos', NULL, NULL, '2018-05-25 21:14:53', 1, '445.687.874-51', NULL, 1, NULL, NULL, NULL, 1),
	(85, 'Você finalizou o cadastro Sr(a)  no Garimpo, agora você pode comprar e vender', NULL, NULL, '2018-05-25 21:16:47', 1, '445.687.874-51', NULL, 1, NULL, NULL, NULL, 1),
	(86, 'Olá sr(a) nerd girl você efetuou o cadastro do seu produto All Star superman, agora é só aguardar os administradores aceitarem para que seu produto fique ativo. seu produto cadastrado foi um(a) All Star supermancom1 unidade(s)', NULL, NULL, '2018-05-25 21:30:06', 1, '445.687.874-51', 109, 1, NULL, NULL, NULL, 1),
	(87, 'Olá sr(a) Administrador, o usuário Administrador inseriu um novo produto no sistema, irá aparecer na página Moderar Produtos, Atenciosamente Garimpo.', NULL, NULL, '2018-05-25 21:30:06', 1, '1', 109, 1, NULL, NULL, NULL, NULL),
	(88, 'Sr(a) nerd girl, seu produto foi aprovado no sistema.', NULL, NULL, '2018-05-25 21:31:11', 1, '445.687.874-51', 109, 5, NULL, NULL, NULL, 1),
	(89, 'Olá sr(a) nerd girl você efetuou o cadastro do seu produto  Tênis para Gamers e Geeks, agora é só aguardar os administradores aceitarem para que seu produto fique ativo. seu produto cadastrado foi um(a)  Tênis para Gamers e Geekscom1 unidade(s)', NULL, NULL, '2018-05-25 21:36:49', 1, '445.687.874-51', 110, 1, NULL, NULL, NULL, 1),
	(90, 'Olá sr(a) Administrador, o usuário Administrador inseriu um novo produto no sistema, irá aparecer na página Moderar Produtos, Atenciosamente Garimpo.', NULL, NULL, '2018-05-25 21:36:49', 1, '1', 110, 1, NULL, NULL, NULL, NULL),
	(91, 'Sr(a) nerd girl, seu produto foi aprovado no sistema.', NULL, NULL, '2018-05-25 21:36:55', 1, '445.687.874-51', 110, 5, NULL, NULL, NULL, 1),
	(92, 'Olá sr(a) gabriel de paula  você efetuou o cadastro do seu produto TESTE, agora é só aguardar os administradores aceitarem para que seu produto fique ativo. seu produto cadastrado foi um(a) TESTEcom1 unidade(s)', NULL, NULL, '2018-05-25 21:54:19', 1, '436.606.008-65', 111, 1, NULL, NULL, NULL, 0),
	(93, 'Olá sr(a) Administrador, o usuário Administrador inseriu um novo produto no sistema, irá aparecer na página Moderar Produtos, Atenciosamente Garimpo.', NULL, NULL, '2018-05-25 21:54:19', 1, '1', 111, 1, NULL, NULL, NULL, NULL),
	(94, 'Sr(a) gabriel de paula , seu produto foi aprovado no sistema.', NULL, NULL, '2018-05-25 21:54:31', 1, '436.606.008-65', 111, 5, NULL, NULL, NULL, 0),
	(95, 'Olá sr(a) gabriel de paula  seu produto foi alterado com sucessoTESTE, ele passará por uma nova moderação dos administrados.', NULL, NULL, '2018-05-25 21:58:39', 1, '436.606.008-65', 111, 7, NULL, NULL, NULL, 0),
	(96, 'Olá sr(a) Administrador, o usuário Administrador modificou um produto no sistema,', NULL, NULL, '2018-05-25 21:58:39', 1, '1', 111, 1, NULL, NULL, NULL, NULL),
	(97, 'Olá sr(a) gabriel de paula  seu produto foi alterado com sucessoaltereis, ele passará por uma nova moderação dos administrados.', NULL, NULL, '2018-05-25 22:02:06', 1, '436.606.008-65', 111, 7, NULL, NULL, NULL, 0),
	(98, 'Olá sr(a) Administrador, o usuário Administrador modificou um produto no sistema,', NULL, NULL, '2018-05-25 22:02:06', 1, '1', 111, 1, NULL, NULL, NULL, NULL),
	(99, 'Olá sr(a) gabriel de paula  seu produto foi alterado com sucessoalterando, ele passará por uma nova moderação dos administrados.', NULL, NULL, '2018-05-25 22:16:48', 1, '436.606.008-65', 111, 7, NULL, NULL, NULL, 0),
	(100, 'Olá sr(a) Administrador, o usuário Administrador modificou um produto no sistema,', NULL, NULL, '2018-05-25 22:16:48', 1, '1', 111, 1, NULL, NULL, NULL, NULL),
	(101, 'Olá sr(a) gabriel de paula  seu produto foi alterado com sucessoAlterei, ele passará por uma nova moderação dos administrados.', NULL, NULL, '2018-05-25 22:25:25', 1, '436.606.008-65', 111, 7, NULL, NULL, NULL, 0),
	(102, 'Olá sr(a) Administrador, o usuário Administrador modificou um produto no sistema,', NULL, NULL, '2018-05-25 22:25:25', 1, '1', 111, 1, NULL, NULL, NULL, NULL),
	(103, 'Olá sr(a) gabriel de paula  seu produto foi alterado com sucessoAlterei, ele passará por uma nova moderação dos administrados.', NULL, NULL, '2018-05-25 22:27:52', 1, '436.606.008-65', 111, 7, NULL, NULL, NULL, 0),
	(104, 'Olá sr(a) Administrador, o usuário Administrador modificou um produto no sistema,', NULL, NULL, '2018-05-25 22:28:13', 1, '1', 111, 1, NULL, NULL, NULL, NULL),
	(105, 'Olá sr(a) gabriel de paula  seu produto foi alterado com sucessoAlterei, ele passará por uma nova moderação dos administrados.', NULL, NULL, '2018-05-25 22:35:17', 1, '436.606.008-65', 111, 7, NULL, NULL, NULL, 0),
	(106, 'Olá sr(a) Administrador, o usuário Administrador modificou um produto no sistema,', NULL, NULL, '2018-05-25 22:35:17', 1, '1', 111, 1, NULL, NULL, NULL, NULL),
	(107, 'Olá sr(a) gabriel de paula  seu produto foi alterado com sucessoAlterei, ele passará por uma nova moderação dos administrados.', NULL, NULL, '2018-05-25 22:35:24', 1, '436.606.008-65', 111, 7, NULL, NULL, NULL, 0),
	(108, 'Olá sr(a) Administrador, o usuário Administrador modificou um produto no sistema,', NULL, NULL, '2018-05-25 22:35:24', 1, '1', 111, 1, NULL, NULL, NULL, NULL),
	(109, 'Olá sr(a) gabriel de paula  seu produto foi alterado com sucessoAlterei, ele passará por uma nova moderação dos administrados.', NULL, NULL, '2018-05-25 22:35:33', 1, '436.606.008-65', 111, 7, NULL, NULL, NULL, 0),
	(110, 'Olá sr(a) Administrador, o usuário Administrador modificou um produto no sistema,', NULL, NULL, '2018-05-25 22:35:33', 1, '1', 111, 1, NULL, NULL, NULL, NULL),
	(111, 'Olá sr(a) gabriel de paula  seu produto foi alterado com sucessoAlterei, ele passará por uma nova moderação dos administrados.', NULL, NULL, '2018-05-25 22:35:34', 1, '436.606.008-65', 111, 7, NULL, NULL, NULL, 0),
	(112, 'Olá sr(a) Administrador, o usuário Administrador modificou um produto no sistema,', NULL, NULL, '2018-05-25 22:35:34', 1, '1', 111, 1, NULL, NULL, NULL, NULL),
	(113, 'Olá sr(a) gabriel de paula  seu produto foi alterado com sucessoAlterei, ele passará por uma nova moderação dos administrados.', NULL, NULL, '2018-05-25 22:35:35', 1, '436.606.008-65', 111, 7, NULL, NULL, NULL, 0),
	(114, 'Olá sr(a) Administrador, o usuário Administrador modificou um produto no sistema,', NULL, NULL, '2018-05-25 22:35:35', 1, '1', 111, 1, NULL, NULL, NULL, NULL),
	(115, 'Olá sr(a) gabriel de paula  seu produto foi alterado com sucessoAlterei, ele passará por uma nova moderação dos administrados.', NULL, NULL, '2018-05-25 22:35:36', 1, '436.606.008-65', 111, 7, NULL, NULL, NULL, 0),
	(116, 'Olá sr(a) Administrador, o usuário Administrador modificou um produto no sistema,', NULL, NULL, '2018-05-25 22:35:36', 1, '1', 111, 1, NULL, NULL, NULL, NULL),
	(117, 'Olá sr(a) gabriel de paula  seu produto foi alterado com sucessoAlterei, ele passará por uma nova moderação dos administrados.', NULL, NULL, '2018-05-25 22:35:36', 1, '436.606.008-65', 111, 7, NULL, NULL, NULL, 0),
	(118, 'Olá sr(a) Administrador, o usuário Administrador modificou um produto no sistema,', NULL, NULL, '2018-05-25 22:35:36', 1, '1', 111, 1, NULL, NULL, NULL, NULL),
	(119, 'Olá sr(a) gabriel de paula  seu produto foi alterado com sucessoAlterei, ele passará por uma nova moderação dos administrados.', NULL, NULL, '2018-05-25 22:35:37', 1, '436.606.008-65', 111, 7, NULL, NULL, NULL, 0),
	(120, 'Olá sr(a) Administrador, o usuário Administrador modificou um produto no sistema,', NULL, NULL, '2018-05-25 22:35:37', 1, '1', 111, 1, NULL, NULL, NULL, NULL),
	(121, 'Olá sr(a) gabriel de paula  seu produto foi alterado com sucessoaltereis, ele passará por uma nova moderação dos administrados.', NULL, NULL, '2018-05-25 22:39:30', 1, '436.606.008-65', 111, 7, NULL, NULL, NULL, 0),
	(122, 'Olá sr(a) Administrador, o usuário Administrador modificou um produto no sistema,', NULL, NULL, '2018-05-25 22:39:30', 1, '1', 111, 1, NULL, NULL, NULL, NULL),
	(123, 'Olá sr(a) gabriel de paula  seu produto foi alterado com sucessoaaa, ele passará por uma nova moderação dos administrados.', NULL, NULL, '2018-05-25 22:40:58', 1, '436.606.008-65', 111, 7, NULL, NULL, NULL, 0),
	(124, 'Olá sr(a) Administrador, o usuário Administrador modificou um produto no sistema,', NULL, NULL, '2018-05-25 22:40:58', 1, '1', 111, 1, NULL, NULL, NULL, NULL),
	(125, 'Olá sr(a) gabriel de paula  seu produto foi alterado com sucessoalterei, ele passará por uma nova moderação dos administrados.', NULL, NULL, '2018-05-25 22:42:06', 1, '436.606.008-65', 111, 7, NULL, NULL, NULL, 0),
	(126, 'Olá sr(a) Administrador, o usuário Administrador modificou um produto no sistema,', NULL, NULL, '2018-05-25 22:42:06', 1, '1', 111, 1, NULL, NULL, NULL, NULL),
	(127, 'Olá sr(a) gabriel de paula  seu produto foi alterado com sucessoaaaaaaa, ele passará por uma nova moderação dos administrados.', NULL, NULL, '2018-05-25 22:43:56', 1, '436.606.008-65', 111, 7, NULL, NULL, NULL, 0),
	(128, 'Olá sr(a) Administrador, o usuário Administrador modificou um produto no sistema,', NULL, NULL, '2018-05-25 22:43:56', 1, '1', 111, 1, NULL, NULL, NULL, NULL),
	(129, 'Olá sr(a) gabriel de paula  seu produto foi alterado com sucessoaaaaa, ele passará por uma nova moderação dos administrados.', NULL, NULL, '2018-05-25 23:04:54', 1, '436.606.008-65', 111, 7, NULL, NULL, NULL, 0),
	(130, 'Olá sr(a) Administrador, o usuário Administrador modificou um produto no sistema,', NULL, NULL, '2018-05-25 23:04:54', 1, '1', 111, 1, NULL, NULL, NULL, NULL),
	(131, 'Sr(a) gabriel de paula , seu produto foi aprovado no sistema.', NULL, NULL, '2018-05-25 23:09:19', 1, '436.606.008-65', 111, 5, NULL, NULL, NULL, 0),
	(132, 'Olá sr(a) gabriel de paula  seu produto foi alterado com sucessoaaaaa, ele passará por uma nova moderação dos administrados.', NULL, NULL, '2018-05-25 23:12:11', 1, '436.606.008-65', 111, 7, NULL, NULL, NULL, 0),
	(133, 'Olá sr(a) Administrador, o usuário Administrador modificou um produto no sistema,', NULL, NULL, '2018-05-25 23:12:11', 1, '1', 111, 1, NULL, NULL, NULL, NULL),
	(134, 'Olá sr(a) gabriel de paula  seu produto foi alterado com sucessoaaaaa, ele passará por uma nova moderação dos administrados.', NULL, NULL, '2018-05-25 23:12:34', 1, '436.606.008-65', 111, 7, NULL, NULL, NULL, 0),
	(135, 'Olá sr(a) Administrador, o usuário Administrador modificou um produto no sistema,', NULL, NULL, '2018-05-25 23:12:34', 1, '1', 111, 1, NULL, NULL, NULL, NULL),
	(136, 'Sr(a) gabriel de paula , seu produto foi aprovado no sistema.', NULL, NULL, '2018-05-25 23:13:44', 1, '436.606.008-65', 111, 5, NULL, NULL, NULL, 0),
	(137, 'Olá sr(a) gabriel de paula  seu produto foi alterado com sucessoaaaaa, ele passará por uma nova moderação dos administrados.', NULL, NULL, '2018-05-25 23:24:10', 1, '436.606.008-65', 111, 7, NULL, NULL, NULL, 0),
	(138, 'Olá sr(a) Administrador, o usuário Administrador modificou um produto no sistema,', NULL, NULL, '2018-05-25 23:24:10', 1, '1', 111, 1, NULL, NULL, NULL, NULL),
	(139, 'Sr(a) gabriel de paula , seu produto foi aprovado no sistema.', NULL, NULL, '2018-05-25 23:24:43', 1, '436.606.008-65', 111, 5, NULL, NULL, NULL, 1),
	(140, 'Olá sr(a) gabriel de paula  seu produto foi alterado com sucessoalterado, ele passará por uma nova moderação dos administrados.', NULL, NULL, '2018-05-25 23:25:04', 1, '436.606.008-65', 111, 7, NULL, NULL, NULL, 1),
	(141, 'Olá sr(a) Administrador, o usuário Administrador modificou um produto no sistema,', NULL, NULL, '2018-05-25 23:25:04', 1, '1', 111, 1, NULL, NULL, NULL, NULL),
	(142, 'Olá sr(a) gabriel de paula  seu produto foi alterado com sucessoalterado, ele passará por uma nova moderação dos administrados.', NULL, NULL, '2018-05-25 23:25:09', 1, '436.606.008-65', 111, 7, NULL, NULL, NULL, 1),
	(143, 'Olá sr(a) Administrador, o usuário Administrador modificou um produto no sistema,', NULL, NULL, '2018-05-25 23:25:09', 1, '1', 111, 1, NULL, NULL, NULL, NULL),
	(144, 'Olá sr(a) gabriel de paula  seu produto foi alterado com sucessoAaaaaaaaAA, ele passará por uma nova moderação dos administrados.', NULL, NULL, '2018-05-25 23:25:49', 1, '436.606.008-65', 111, 7, NULL, NULL, NULL, 1),
	(145, 'Olá sr(a) Administrador, o usuário Administrador modificou um produto no sistema,', NULL, NULL, '2018-05-25 23:25:49', 1, '1', 111, 1, NULL, NULL, NULL, NULL),
	(146, 'Olá sr(a) gabriel de paula  seu produto foi alterado com sucessoAlterado, ele passará por uma nova moderação dos administrados.', NULL, NULL, '2018-05-25 23:26:17', 1, '436.606.008-65', 111, 7, NULL, NULL, NULL, 1),
	(147, 'Olá sr(a) Administrador, o usuário Administrador modificou um produto no sistema,', NULL, NULL, '2018-05-25 23:26:17', 1, '1', 111, 1, NULL, NULL, NULL, NULL),
	(148, 'Seja muito bem-vindo Sr(a) Costa freire ao Garimpo, aqui você pode vender seus produtos e também comprar novos produtos', NULL, NULL, '2018-05-26 02:48:37', 1, '457.897.465-13', NULL, 1, NULL, NULL, NULL, 1),
	(149, 'Você finalizou o cadastro Sr(a)  no Garimpo, agora você pode comprar e vender', NULL, NULL, '2018-05-26 02:49:53', 1, '457.897.465-13', NULL, 1, NULL, NULL, NULL, 1),
	(150, 'Olá sr(a) Administrador, o usuário Administrador inseriu um novo produto no sistema, irá aparecer na página Moderar Produtos, Atenciosamente Garimpo.', NULL, NULL, '2018-05-26 02:54:01', 1, '1', 112, 1, NULL, NULL, NULL, NULL),
	(151, 'Sr(a) gabriel de paula , seu produto não foi aprovado no sistema, modifique-o para uma nova moderação', NULL, NULL, '2018-05-26 02:54:31', 1, '436.606.008-65', 111, 6, NULL, NULL, NULL, 1),
	(152, 'Sr(a) Costa freire, seu produto foi aprovado no sistema.', NULL, NULL, '2018-05-26 02:54:35', 1, '457.897.465-13', 112, 5, NULL, NULL, NULL, 1),
	(153, 'Olá sr(a) gabriel de paula  você efetuou o cadastro do seu produto Call Of Duty - Black Ops , agora é só aguardar os administradores aceitarem para que seu produto fique ativo. seu produto cadastrado foi um(a) Call Of Duty - Black Ops com8 unidade(s)', NULL, NULL, '2018-05-26 03:32:31', 1, '436.606.008-65', 113, 1, NULL, NULL, NULL, 1),
	(154, 'Olá sr(a) Administrador, o usuário gabriel de paula  inseriu um novo produto no sistema, irá aparecer na página Moderar Produtos, Atenciosamente Garimpo.', NULL, NULL, '2018-05-26 03:32:31', 1, '1', 113, 1, NULL, NULL, NULL, NULL),
	(155, 'Sr(a) gabriel de paula , seu produto foi aprovado no sistema.', NULL, NULL, '2018-05-26 03:32:43', 1, '436.606.008-65', 113, 5, NULL, NULL, NULL, 1),
	(156, 'Seja muito bem-vindo Sr(a) antonio almeida ao Garimpo, aqui você pode vender seus produtos e também comprar novos produtos', NULL, NULL, '2018-05-26 03:42:32', 1, '216.561.235-55', NULL, 1, NULL, NULL, NULL, 0),
	(157, 'Você finalizou o cadastro Sr(a)  no Garimpo, agora você pode comprar e vender', NULL, NULL, '2018-05-26 03:43:53', 1, '216.561.235-55', NULL, 1, NULL, NULL, NULL, 0),
	(158, 'Olá sr(a) Administrador, o usuário antonio almeida inseriu um novo produto no sistema, irá aparecer na página Moderar Produtos, Atenciosamente Garimpo.', NULL, NULL, '2018-05-26 03:46:11', 1, '1', 114, 1, NULL, NULL, NULL, NULL),
	(159, 'Sr(a) antonio almeida, seu produto foi aprovado no sistema.', NULL, NULL, '2018-05-26 03:47:27', 1, '216.561.235-55', 114, 5, NULL, NULL, NULL, 0),
	(160, 'Seja muito bem-vindo Sr(a) teste alterar ao Garimpo, aqui você pode vender seus produtos e também comprar novos produtos', NULL, NULL, '2018-05-26 04:11:26', 0, '111.256.734-54', NULL, 1, NULL, NULL, NULL, 1),
	(161, 'Você finalizou o cadastro Sr(a)  no Garimpo, agora você pode comprar e vender', NULL, NULL, '2018-05-26 04:11:55', 0, '111.256.734-54', NULL, 1, NULL, NULL, NULL, 1),
	(162, 'Seja muito bem-vindo Sr(a) cadastro rapdo ao Garimpo, aqui você pode vender seus produtos e também comprar novos produtos', NULL, NULL, '2018-05-26 04:15:14', 1, '217.832.455-52', NULL, 1, NULL, NULL, NULL, 1),
	(163, 'Você finalizou o cadastro Sr(a)  no Garimpo, agora você pode comprar e vender', NULL, NULL, '2018-05-26 04:15:45', 1, '217.832.455-52', NULL, 1, NULL, NULL, NULL, 1),
	(164, 'faz por 99?', NULL, NULL, '2018-05-26 04:23:18', 1, '756.475.445-11', 108, 2, '260520182318348', '436.606.008-65', 1, 1),
	(165, 'faço por 99,50', NULL, NULL, '2018-05-26 04:24:18', 1, '436.606.008-65', 108, 3, '260520182318348', NULL, NULL, 1),
	(166, 'Tem outros tamanhos ou só esse?', NULL, NULL, '2018-05-26 04:25:15', 1, '436.606.008-65', 106, 2, '260520182515315', '756.475.445-11', 1, 1),
	(167, 'você tem ela ainda?', NULL, NULL, '2018-05-26 04:25:47', 1, '457.897.465-13', 112, 2, '260520182547740', '756.475.445-11', 1, 1),
	(168, 'tenho, e vou adicionar mais iguais a ela no garimpo', NULL, NULL, '2018-05-26 04:26:29', 1, '756.475.445-11', 112, 3, '260520182547740', NULL, NULL, 1),
	(169, 'só esse mesmo', NULL, NULL, '2018-05-26 04:39:53', 1, '756.475.445-11', 106, 3, '260520182515315', NULL, NULL, 1),
	(170, 'Olá sr(a) gabriel de paula  você efetuou o cadastro do seu produto Tênis Sonic, agora é só aguardar os administradores aceitarem para que seu produto fique ativo. seu produto cadastrado foi um(a) Tênis Soniccom1 unidade(s)', NULL, NULL, '2018-05-26 04:41:58', 1, '436.606.008-65', 115, 1, NULL, NULL, NULL, 1),
	(171, 'Olá sr(a) Administrador, o usuário gabriel de paula  inseriu um novo produto no sistema, irá aparecer na página Moderar Produtos, Atenciosamente Garimpo.', NULL, NULL, '2018-05-26 04:41:58', 1, '1', 115, 1, NULL, NULL, NULL, NULL),
	(172, 'Sr(a) gabriel de paula , seu produto foi aprovado no sistema.', NULL, NULL, '2018-05-26 04:42:22', 1, '436.606.008-65', 115, 5, NULL, NULL, NULL, 1),
	(173, 'tem camisa do black ops 1?', NULL, NULL, '2018-05-26 04:44:50', 1, '436.606.008-65', 113, 2, '260520184450983', '445.687.874-51', 1, 1),
	(174, 'tem outros tipos de caneca?', NULL, NULL, '2018-05-26 04:45:19', 1, '216.561.235-55', 114, 2, '260520184519685', '445.687.874-51', 1, 0),
	(175, 'Abaixa mais ainda o preço?', NULL, NULL, '2018-05-26 04:45:52', 1, '216.561.235-55', 114, 2, '260520184552013', '457.897.465-13', 1, 0),
	(176, 'nao tenho', NULL, NULL, '2018-05-26 14:56:21', 1, '445.687.874-51', 113, 3, '260520184450983', NULL, NULL, 1),
	(177, 'Seja muito bem-vindo Sr(a) alana campos ao Garimpo, aqui você pode vender seus produtos e também comprar novos produtos', NULL, NULL, '2018-05-26 15:07:43', 1, '155.477.841-11', NULL, 1, NULL, NULL, NULL, 0),
	(178, 'Você finalizou o cadastro Sr(a)  no Garimpo, agora você pode comprar e vender', NULL, NULL, '2018-05-26 15:08:39', 1, '155.477.841-11', NULL, 1, NULL, NULL, NULL, 0),
	(179, 'Olá sr(a) alana campos você efetuou o cadastro do seu produto caneca Magica 3d em porcelana , agora é só aguardar os administradores aceitarem para que seu produto fique ativo. seu produto cadastrado foi um(a) caneca Magica 3d em porcelana com9 unidade(s)', NULL, NULL, '2018-05-26 15:22:33', 1, '155.477.841-11', 116, 1, NULL, NULL, NULL, 0),
	(180, 'Olá sr(a) Administrador, o usuário alana campos inseriu um novo produto no sistema, irá aparecer na página Moderar Produtos, Atenciosamente Garimpo.', NULL, NULL, '2018-05-26 15:22:33', 1, '1', 116, 1, NULL, NULL, NULL, NULL),
	(181, 'Sr(a) alana campos, seu produto foi aprovado no sistema.', NULL, NULL, '2018-05-26 15:24:10', 1, '155.477.841-11', 116, 5, NULL, NULL, NULL, 0),
	(182, 'Olá sr(a) alana campos você efetuou o cadastro do seu produto Camisa de programador, agora é só aguardar os administradores aceitarem para que seu produto fique ativo. seu produto cadastrado foi um(a) Camisa de programadorcom10 unidade(s)', NULL, NULL, '2018-05-26 15:37:34', 1, '155.477.841-11', 117, 1, NULL, NULL, NULL, 0),
	(183, 'Olá sr(a) Administrador, o usuário alana campos inseriu um novo produto no sistema, irá aparecer na página Moderar Produtos, Atenciosamente Garimpo.', NULL, NULL, '2018-05-26 15:37:34', 1, '1', 117, 1, NULL, NULL, NULL, NULL),
	(184, 'Sr(a) alana campos, seu produto foi aprovado no sistema.', NULL, NULL, '2018-05-26 15:38:00', 1, '155.477.841-11', 117, 5, NULL, NULL, NULL, 0),
	(185, 'Olá sr(a) alana campos você efetuou o cadastro do seu produto Camiseta Guns N\' Roses , agora é só aguardar os administradores aceitarem para que seu produto fique ativo. seu produto cadastrado foi um(a) Camiseta Guns N\' Roses com6 unidade(s)', NULL, NULL, '2018-05-26 15:49:16', 1, '155.477.841-11', 118, 1, NULL, NULL, NULL, 0),
	(186, 'Olá sr(a) Administrador, o usuário alana campos inseriu um novo produto no sistema, irá aparecer na página Moderar Produtos, Atenciosamente Garimpo.', NULL, NULL, '2018-05-26 15:49:16', 1, '1', 118, 1, NULL, NULL, NULL, NULL),
	(187, 'Sr(a) alana campos, seu produto foi aprovado no sistema.', NULL, NULL, '2018-05-26 15:51:49', 1, '155.477.841-11', 118, 5, NULL, NULL, NULL, 0),
	(188, 'você possui este modelo para adulto também?', NULL, NULL, '2018-05-26 15:54:09', 1, '445.687.874-51', 109, 2, '260520185409797', '155.477.841-11', 1, 1),
	(189, 'teria na cor branca? e abaixaria mais um pouco o preço?', NULL, NULL, '2018-05-26 15:54:34', 1, '216.561.235-55', 114, 2, '260520185434744', '155.477.841-11', 1, 0),
	(190, 'está online?', NULL, NULL, '2018-05-26 16:27:26', 1, '756.475.445-11', 108, 2, '260520182726282', '216.561.235-55', 1, 1),
	(191, 'somente de criança', NULL, NULL, '2018-05-26 16:28:24', 1, '155.477.841-11', 109, 3, '260520185409797', NULL, NULL, 0),
	(192, 'Seja muito bem-vindo Sr(a) joana Krat ao Garimpo, aqui você pode vender seus produtos e também comprar novos produtos', NULL, NULL, '2018-05-26 16:29:33', 1, '126.782.342-31', NULL, 1, NULL, NULL, NULL, 1),
	(193, 'Você finalizou o cadastro Sr(a)  no Garimpo, agora você pode comprar e vender', NULL, NULL, '2018-05-26 16:31:24', 1, '126.782.342-31', NULL, 1, NULL, NULL, NULL, 1),
	(194, 'Olá sr(a) joana Krat você efetuou o cadastro do seu produto Caneca Guns N\' Roses, agora é só aguardar os administradores aceitarem para que seu produto fique ativo. seu produto cadastrado foi um(a) Caneca Guns N\' Rosescom8 unidade(s)', NULL, NULL, '2018-05-26 16:36:42', 1, '126.782.342-31', 119, 1, NULL, NULL, NULL, 1),
	(195, 'Olá sr(a) Administrador, o usuário joana Krat inseriu um novo produto no sistema, irá aparecer na página Moderar Produtos, Atenciosamente Garimpo.', NULL, NULL, '2018-05-26 16:36:42', 1, '1', 119, 1, NULL, NULL, NULL, NULL),
	(196, 'Sr(a) joana Krat, seu produto foi aprovado no sistema.', NULL, NULL, '2018-05-26 16:37:00', 1, '126.782.342-31', 119, 5, NULL, NULL, NULL, 1),
	(197, 'Olá sr(a) joana Krat você efetuou o cadastro do seu produto Tenis Guns N\' Roses, agora é só aguardar os administradores aceitarem para que seu produto fique ativo. seu produto cadastrado foi um(a) Tenis Guns N\' Rosescom1 unidade(s)', NULL, NULL, '2018-05-26 16:40:37', 1, '126.782.342-31', 120, 1, NULL, NULL, NULL, 1),
	(198, 'Olá sr(a) Administrador, o usuário joana Krat inseriu um novo produto no sistema, irá aparecer na página Moderar Produtos, Atenciosamente Garimpo.', NULL, NULL, '2018-05-26 16:40:37', 1, '1', 120, 1, NULL, NULL, NULL, NULL),
	(199, 'Sr(a) joana Krat, seu produto foi aprovado no sistema.', NULL, NULL, '2018-05-26 16:40:43', 1, '126.782.342-31', 120, 5, NULL, NULL, NULL, 1),
	(200, 'Olá sr(a) joana Krat você efetuou o cadastro do seu produto Bolsa Slipknot, agora é só aguardar os administradores aceitarem para que seu produto fique ativo. seu produto cadastrado foi um(a) Bolsa Slipknotcom5 unidade(s)', NULL, NULL, '2018-05-26 16:44:14', 1, '126.782.342-31', 121, 1, NULL, NULL, NULL, 1),
	(201, 'Olá sr(a) Administrador, o usuário joana Krat inseriu um novo produto no sistema, irá aparecer na página Moderar Produtos, Atenciosamente Garimpo.', NULL, NULL, '2018-05-26 16:44:14', 1, '1', 121, 1, NULL, NULL, NULL, 0),
	(202, 'Sr(a) joana Krat, seu produto foi aprovado no sistema.', NULL, NULL, '2018-05-26 16:44:19', 1, '126.782.342-31', 121, 5, NULL, NULL, NULL, 1),
	(203, 'Olá sr(a) joana Krat você efetuou o cadastro do seu produto Bolsa Metallica, agora é só aguardar os administradores aceitarem para que seu produto fique ativo. seu produto cadastrado foi um(a) Bolsa Metallicacom1 unidade(s)', NULL, NULL, '2018-05-26 16:53:57', 0, '126.782.342-31', 122, 1, NULL, NULL, NULL, 1),
	(204, 'Olá sr(a) Administrador, o usuário joana Krat inseriu um novo produto no sistema, irá aparecer na página Moderar Produtos, Atenciosamente Garimpo.', NULL, NULL, '2018-05-26 16:53:57', 1, '1', 122, 1, NULL, NULL, NULL, 0),
	(205, 'Sr(a) joana Krat, seu produto foi aprovado no sistema.', NULL, NULL, '2018-05-26 16:54:05', 0, '126.782.342-31', 122, 5, NULL, NULL, NULL, 1),
	(206, 'Olá sr(a) gabriel de paula  seu produto foi alterado com sucessoAlterado, ele passará por uma nova moderação dos administrados.', NULL, NULL, '2018-05-26 17:14:48', 1, '436.606.008-65', 111, 7, NULL, NULL, NULL, 1),
	(207, 'Olá sr(a) Administrador, o usuário Administrador modificou um produto no sistema,', NULL, NULL, '2018-05-26 17:14:48', 1, '1', 111, 1, NULL, NULL, NULL, 0),
	(208, 'Sr(a) gabriel de paula , seu produto foi aprovado no sistema.', NULL, NULL, '2018-05-26 17:35:41', 1, '436.606.008-65', 111, 5, NULL, NULL, NULL, 1),
	(209, 'Sr(a) gabriel de paula , seu produto foi aprovado no sistema.', NULL, NULL, '2018-05-26 22:30:01', 1, '436.606.008-65', 111, 5, NULL, NULL, NULL, 1),
	(210, 'Sr(a) gabriel de paula , seu produto foi aprovado no sistema.', NULL, NULL, '2018-05-26 22:49:49', 1, '436.606.008-65', 111, 5, NULL, NULL, NULL, 1),
	(211, 'Sr(a) gabriel de paula , seu produto foi aprovado no sistema.', NULL, NULL, '2018-05-26 22:52:45', 1, '436.606.008-65', 111, 5, NULL, NULL, NULL, 1),
	(212, 'Sr(a) gabriel de paula , seu produto foi aprovado no sistema.', NULL, NULL, '2018-05-26 22:53:53', 1, '436.606.008-65', 111, 5, NULL, NULL, NULL, 1),
	(213, 'Sr(a) gabriel de paula , seu produto foi aprovado no sistema.', NULL, NULL, '2018-05-26 22:59:13', 1, '436.606.008-65', 111, 5, NULL, NULL, NULL, 1),
	(214, 'Sr(a) gabriel de paula , seu produto foi aprovado no sistema.', NULL, NULL, '2018-05-26 22:59:55', 1, '436.606.008-65', 111, 5, NULL, NULL, NULL, 1),
	(215, 'Sr(a) gabriel de paula , seu produto foi aprovado no sistema.', NULL, NULL, '2018-05-26 23:03:23', 1, '436.606.008-65', 111, 5, NULL, NULL, NULL, 1),
	(216, 'Sr(a) gabriel de paula , seu produto foi aprovado no sistema.', NULL, NULL, '2018-05-26 23:05:56', 1, '436.606.008-65', 111, 5, NULL, NULL, NULL, 1),
	(217, 'Sr(a) gabriel de paula , seu produto foi aprovado no sistema.', NULL, NULL, '2018-05-26 23:08:51', 1, '436.606.008-65', 111, 5, NULL, NULL, NULL, 1),
	(218, 'Sr(a) gabriel de paula , seu produto foi aprovado no sistema.', NULL, NULL, '2018-05-26 23:29:26', 1, '436.606.008-65', 111, 5, NULL, NULL, NULL, 1),
	(219, 'Sr(a) gabriel de paula , seu produto foi aprovado no sistema.', NULL, NULL, '2018-05-26 23:32:15', 1, '436.606.008-65', 111, 5, NULL, NULL, NULL, 1),
	(220, 'Sr(a) gabriel de paula , seu produto não foi aprovado no sistema, modifique-o para uma nova moderação', NULL, NULL, '2018-05-27 02:10:56', 1, '436.606.008-65', 111, 6, NULL, NULL, NULL, 1),
	(221, 'Sr(a) gabriel de paula , seu produto foi aprovado no sistema.', NULL, NULL, '2018-05-27 02:14:09', 1, '436.606.008-65', 105, 5, NULL, NULL, NULL, 1),
	(222, 'Seja muito bem-vindo Sr(a) sandra maria ao Garimpo, aqui você pode vender seus produtos e também comprar novos produtos', NULL, NULL, '2018-05-27 02:56:38', 1, '125.661.223-55', NULL, 1, NULL, NULL, NULL, 1),
	(223, 'Você finalizou o cadastro Sr(a)  no Garimpo, agora você pode comprar e vender', NULL, NULL, '2018-05-27 02:58:08', 1, '125.661.223-55', NULL, 1, NULL, NULL, NULL, 1),
	(224, 'Olá sr(a) sandra maria você efetuou o cadastro do seu produto Relógio De Pulso Hard Rock, agora é só aguardar os administradores aceitarem para que seu produto fique ativo. seu produto cadastrado foi um(a) Relógio De Pulso Hard Rockcom1 unidade(s)', NULL, NULL, '2018-05-27 03:01:46', 1, '125.661.223-55', 123, 1, NULL, NULL, NULL, 1),
	(225, 'Olá sr(a) Administrador, o usuário sandra maria inseriu um novo produto no sistema, irá aparecer na página Moderar Produtos, Atenciosamente Garimpo.', NULL, NULL, '2018-05-27 03:01:46', 1, '1', 123, 1, NULL, NULL, NULL, 0),
	(226, 'Sr(a) sandra maria, seu produto foi aprovado no sistema.', NULL, NULL, '2018-05-27 03:02:17', 1, '125.661.223-55', 123, 5, NULL, NULL, NULL, 1),
	(227, 'possui de outros filmes tambem?', NULL, NULL, '2018-05-27 03:03:05', 1, '216.561.235-55', 114, 2, '270520180305889', '125.661.223-55', 1, 0),
	(228, 'faz por 40?', NULL, NULL, '2018-05-27 03:03:35', 1, '457.897.465-13', 112, 2, '270520180335704', '125.661.223-55', 1, 1),
	(229, 'Olá sr(a) sandra maria você efetuou o cadastro do seu produto Bolsa me mine, agora é só aguardar os administradores aceitarem para que seu produto fique ativo. seu produto cadastrado foi um(a) Bolsa me minecom10 unidade(s)', NULL, NULL, '2018-05-27 03:07:44', 1, '125.661.223-55', 124, 1, NULL, NULL, NULL, 1),
	(230, 'Olá sr(a) Administrador, o usuário sandra maria inseriu um novo produto no sistema, irá aparecer na página Moderar Produtos, Atenciosamente Garimpo.', NULL, NULL, '2018-05-27 03:07:44', 1, '1', 124, 1, NULL, NULL, NULL, 0),
	(231, 'Sr(a) sandra maria, seu produto foi aprovado no sistema.', NULL, NULL, '2018-05-27 03:08:03', 1, '125.661.223-55', 124, 5, NULL, NULL, NULL, 1),
	(232, 'sim, já já vou cadastrar elas no garimpo', NULL, NULL, '2018-05-27 03:09:55', 0, '445.687.874-51', 114, 3, '260520184519685', NULL, NULL, 1),
	(233, 'o preço ja está muito baixo, eu tenho na cor branca sim', NULL, NULL, '2018-05-27 03:10:31', 1, '155.477.841-11', 114, 3, '260520185434744', NULL, NULL, 0),
	(234, 'envia para Manaus?', NULL, NULL, '2018-05-27 03:11:11', 1, '457.897.465-13', 112, 2, '270520181111440', '216.561.235-55', 1, 1),
	(235, 'não da amigo', NULL, NULL, '2018-05-27 03:11:45', 1, '457.897.465-13', 114, 3, '260520184552013', NULL, NULL, 1),
	(236, 'tem na cor branca?\r\n', NULL, NULL, '2018-05-27 03:26:37', 1, '436.606.008-65', 113, 2, '270520182637938', '216.561.235-55', 1, 1),
	(237, 'tenho sim', NULL, NULL, '2018-05-27 22:57:38', 1, '216.561.235-55', 113, 3, '270520182637938', NULL, NULL, 0),
	(239, 'Olá sr(a) Administrador, o <a href=\'112\'>produto</a> recebeu uma denúncia alegando estar com foto irregular ', NULL, NULL, '2018-05-29 22:21:56', 1, '1', 112, 1, NULL, NULL, NULL, 0),
	(240, 'Olá sr(a) Administrador, o <a href=\'112\'>produto</a> recebeu uma denúncia alegando estar com foto irregular ', NULL, NULL, '2018-05-29 22:22:51', 1, '1', 112, 1, NULL, NULL, NULL, 0),
	(241, 'Olá sr(a) Administrador, o <a href=\'112\'>produto</a> recebeu uma denúncia alegando estar com descrição irregular ', NULL, NULL, '2018-05-29 22:23:04', 1, '1', 112, 1, NULL, NULL, NULL, 0),
	(242, 'Olá sr(a) Administrador, o <a href=\'/Paginas/Produtos/Produto.aspx?id=\'113\'\'>produto</a> recebeu uma denúncia alegando estar com categoria errada ', NULL, NULL, '2018-05-29 22:24:37', 1, '1', 113, 1, NULL, NULL, NULL, 0),
	(243, 'Olá sr(a) Administrador, o <a href=\'/Paginas/Produtos/Produto.aspx?id=\'113\'\'>produto</a> recebeu uma denúncia alegando estar com foto irregular ', NULL, NULL, '2018-05-29 22:34:46', 1, '1', 113, 8, NULL, NULL, NULL, 0),
	(244, 'Olá sr(a) Administrador, o /*<a href=\'/Paginas/Produtos/Produto.aspx?id=\'108\'\'>*/produto/*</a>*/ recebeu uma denúncia alegando estar com descrição irregular ', NULL, NULL, '2018-05-29 22:42:41', 1, '1', 108, 8, NULL, NULL, NULL, 0),
	(245, 'Olá sr(a) Administrador, o /*<a href=\'/Paginas/Produtos/Produto.aspx?id=\'117\'\'>*/produto/*</a>*/ recebeu uma denúncia alegando estar com descrição irregular ', NULL, NULL, '2018-05-29 22:45:30', 1, '1', 117, 8, NULL, NULL, NULL, 0),
	(246, 'Olá sr(a) gabriel de paula  seu produto recebeu uma denuncia alegando estar com foto irregular, \r\n                            administradores estarão revisando a denúncia e verificando se a denúncia é verídica', NULL, NULL, '2018-05-29 22:50:05', 1, '216.561.235-55', 114, 1, NULL, NULL, NULL, 0),
	(247, 'Olá sr(a) Administrador, o produto recebeu uma denúncia alegando estar com foto irregular ', NULL, NULL, '2018-05-29 22:50:37', 1, '1', 114, 8, NULL, NULL, NULL, 0),
	(248, 'Olá sr(a) 756.475.445-11 seu produto recebeu uma denuncia alegando estar com foto irregular, \r\n                            administradores estarão revisando a denúncia e verificando se a denúncia é verídica', NULL, NULL, '2018-05-29 22:51:25', 1, '756.475.445-11', 108, 8, NULL, NULL, NULL, 0),
	(249, 'Olá sr(a) Administrador, o produto recebeu uma denúncia alegando estar com foto irregular ', NULL, NULL, '2018-05-29 22:51:25', 1, '1', 108, 8, NULL, NULL, NULL, 0),
	(251, 'Olá sr(a) Administrador, o produto recebeu uma denúncia alegando estar com foto irregular ', NULL, NULL, '2018-05-29 22:53:16', 1, '1', 113, 8, NULL, NULL, NULL, 0),
	(253, 'Olá sr(a) Administrador, o produto recebeu uma denúncia alegando estar com descrição irregular ', NULL, NULL, '2018-05-29 22:53:49', 1, '1', 108, 8, NULL, NULL, NULL, 0),
	(254, 'Olá sr(a) gabriel de paula  seu produto recebeu uma denuncia alegando estar com descrição irregular, \r\n                            administradores estarão revisando a denúncia e verificando se a é verídica podendo desativar seu produto.', NULL, NULL, '2018-05-29 22:54:45', 1, '436.606.008-65', 113, 8, NULL, NULL, NULL, 1),
	(255, 'Olá sr(a) Administrador, o produto recebeu uma denúncia alegando estar com descrição irregular ', NULL, NULL, '2018-05-29 22:54:45', 1, '1', 113, 8, NULL, NULL, NULL, 0),
	(256, 'Olá sr(a) marcelo vidas seu produto recebeu uma denuncia alegando estar com descrição irregular, \r\n                            administradores estarão revisando a denúncia e verificando se a é verídica podendo desativar seu produto.', NULL, NULL, '2018-05-29 23:27:40', 0, '756.475.445-11', 108, 8, NULL, NULL, NULL, 1),
	(257, 'Olá sr(a) Administrador, o produto recebeu uma denúncia alegando estar com descrição irregular ', NULL, NULL, '2018-05-29 23:27:40', 1, '1', 108, 8, NULL, NULL, NULL, 0),
	(258, 'Olá sr(a) gabriel de paula  seu produto recebeu uma denuncia alegando estar com foto irregular, \r\n                            administradores estarão revisando a denúncia e verificando se a denúncia é verídica', NULL, NULL, '2018-05-29 23:32:44', 1, '436.606.008-65', 113, 8, NULL, NULL, NULL, 0),
	(259, 'Olá sr(a) Administrador, o produto recebeu uma denúncia alegando estar com foto irregular ', NULL, NULL, '2018-05-29 23:32:44', 1, '1', 113, 8, NULL, NULL, NULL, 0),
	(260, 'Olá sr(a) gabriel de paula  seu produto recebeu uma denuncia alegando estar com categoria errada, \r\n                            administradores estarão revisando a denúncia e verificando se a denúncia é verídica', NULL, NULL, '2018-05-29 23:34:22', 1, '436.606.008-65', 113, 8, NULL, NULL, NULL, 0),
	(261, 'Olá sr(a) Administrador, o produto recebeu uma denúncia alegando estar com categoria errada ', NULL, NULL, '2018-05-29 23:34:22', 1, '1', 113, 8, NULL, NULL, NULL, 0),
	(262, 'Olá sr(a) Costa freire seu produto recebeu uma denuncia alegando estar com categoria errada, \r\n                            administradores estarão revisando a denúncia e verificando se a denúncia é verídica', NULL, NULL, '2018-05-29 23:36:04', 1, '457.897.465-13', 112, 8, NULL, NULL, NULL, 1),
	(263, 'Olá sr(a) Administrador, o produto recebeu uma denúncia alegando estar com categoria errada ', NULL, NULL, '2018-05-29 23:36:04', 1, '1', 112, 8, NULL, NULL, NULL, 0),
	(264, 'Olá sr(a) Costa freire seu produto recebeu uma denuncia alegando estar com categoria errada, \r\n                            administradores estarão revisando a denúncia e verificando se a denúncia é verídica', NULL, NULL, '2018-05-29 23:37:54', 1, '457.897.465-13', 112, 8, NULL, NULL, NULL, 1),
	(265, 'Olá sr(a) Administrador, o produto recebeu uma denúncia alegando estar com categoria errada ', NULL, NULL, '2018-05-29 23:37:54', 1, '1', 112, 8, NULL, NULL, NULL, 0),
	(266, 'sim', NULL, NULL, '2018-05-29 23:38:22', 1, '216.561.235-55', 112, 3, '270520181111440', NULL, NULL, 0),
	(267, 'faço', NULL, NULL, '2018-05-29 23:38:35', 0, '125.661.223-55', 112, 3, '270520180335704', NULL, NULL, 1),
	(268, 'Olá sr(a) Costa freire seu produto recebeu uma denuncia alegando estar com descrição irregular, \r\n                            administradores estarão revisando a denúncia e verificando se a é verídica podendo desativar seu produto.', NULL, NULL, '2018-05-29 23:39:40', 0, '457.897.465-13', 112, 8, NULL, NULL, NULL, 1),
	(269, 'Olá sr(a) Administrador, o produto recebeu uma denúncia alegando estar com descrição irregular ', NULL, NULL, '2018-05-29 23:39:40', 1, '1', 112, 8, NULL, NULL, NULL, 0),
	(270, 'Olá sr(a) gabriel de paula  seu produto foi alterado com sucessoTeste, ele passará por uma nova moderação dos administrados.', NULL, NULL, '2018-06-05 14:46:17', 1, '436.606.008-65', 111, 7, NULL, NULL, NULL, 1),
	(271, 'Olá sr(a) Administrador, o usuário gabriel de paula  modificou um produto no sistema,', NULL, NULL, '2018-06-05 14:46:17', 1, '1', 111, 1, NULL, NULL, NULL, 0),
	(272, 'Olá sr(a) marcelo vidas seu produto recebeu uma denuncia alegando estar com categoria errada, \r\n                            administradores estarão revisando a denúncia e verificando se a denúncia é verídica', NULL, NULL, '2018-06-07 17:58:58', 0, '756.475.445-11', 108, 8, NULL, NULL, NULL, 1),
	(273, 'Olá sr(a) Administrador, o produto recebeu uma denúncia alegando estar com categoria errada ', NULL, NULL, '2018-06-07 17:58:58', 1, '1', 108, 8, NULL, NULL, NULL, NULL),
	(274, 'Olá sr(a) gabriel de paula , o produto recebeu uma denúncia alegando estar com categoria errada ', NULL, NULL, '2018-06-07 17:58:58', 1, '436.606.008-65', 108, 8, NULL, NULL, NULL, NULL),
	(275, 'Olá sr(a) alana campos seu produto recebeu uma denuncia alegando estar com categoria errada, \r\n                            administradores estarão revisando a denúncia e verificando se a denúncia é verídica', NULL, NULL, '2018-06-07 18:01:04', 1, '155.477.841-11', 117, 8, NULL, NULL, NULL, 0),
	(276, 'Olá sr(a) Administrador, o produto recebeu uma denúncia alegando estar com categoria errada ', NULL, NULL, '2018-06-07 18:01:04', 1, '1', 117, 8, NULL, NULL, NULL, NULL),
	(277, 'Olá sr(a) gabriel de paula , o produto recebeu uma denúncia alegando estar com categoria errada ', NULL, NULL, '2018-06-07 18:01:04', 1, '436.606.008-65', 117, 8, NULL, NULL, NULL, NULL),
	(278, 'Olá sr(a) gabriel de paula  seu produto recebeu uma denuncia alegando estar com descrição irregular, \r\n                            administradores estarão revisando a denúncia e verificando se a é verídica podendo desativar seu produto.', NULL, NULL, '2018-06-07 18:04:44', 1, '436.606.008-65', 105, 8, NULL, NULL, NULL, 1),
	(279, 'Olá sr(a) Administrador, este produto recebeu uma denúncia alegando estar com descrição irregular ', NULL, NULL, '2018-06-07 18:04:44', 1, '1', 105, 8, NULL, NULL, NULL, NULL),
	(280, 'Olá sr(a) gabriel de paula , este produto recebeu uma denúncia alegando estar com descrição irregular ', NULL, NULL, '2018-06-07 18:04:44', 1, '436.606.008-65', 105, 8, NULL, NULL, NULL, NULL),
	(281, 'Olá sr(a) alana campos seu produto recebeu uma denuncia alegando estar com descrição irregular, \r\n                            administradores estarão revisando a denúncia e verificando se a é verídica podendo desativar seu produto.', NULL, NULL, '2018-06-07 18:06:22', 1, '155.477.841-11', 117, 8, NULL, NULL, NULL, 0),
	(282, 'Olá sr(a) Administrador, este produto recebeu uma denúncia alegando estar com descrição irregular ', NULL, NULL, '2018-06-07 18:06:22', 1, '1', 117, 8, NULL, NULL, NULL, NULL),
	(283, 'Olá sr(a) gabriel de paula , este produto recebeu uma denúncia alegando estar com descrição irregular ', NULL, NULL, '2018-06-07 18:06:22', 1, '436.606.008-65', 117, 8, NULL, NULL, NULL, NULL),
	(284, 'Olá sr(a) antonio almeida seu produto recebeu uma denuncia alegando estar com foto irregular, \r\n                            administradores estarão revisando a denúncia e verificando se a denúncia é verídica', NULL, NULL, '2018-06-07 18:06:35', 1, '216.561.235-55', 114, 8, NULL, NULL, NULL, 0),
	(285, 'Olá sr(a) Administrador, este produto recebeu uma denúncia alegando estar com foto irregular ', NULL, NULL, '2018-06-07 18:06:35', 1, '1', 114, 8, NULL, NULL, NULL, NULL),
	(286, 'Olá sr(a) gabriel de paula , este produto recebeu uma denúncia alegando estar com foto irregular ', NULL, NULL, '2018-06-07 18:06:35', 1, '436.606.008-65', 114, 8, NULL, NULL, NULL, NULL),
	(287, 'sim possuo', NULL, NULL, '2018-06-07 18:08:32', 0, '125.661.223-55', 114, 3, '270520180305889', NULL, NULL, 1),
	(288, 'Sr(a) gabriel de paula , seu produto foi aprovado no sistema.', NULL, NULL, '2018-06-08 01:29:43', 1, '436.606.008-65', 111, 5, NULL, NULL, NULL, 1),
	(289, 'Olá sr(a) Administrador, o usuário gabriel de paula  alterou um produto no sistema, irá aparecer na página Moderar Produtos, Atenciosamente Garimpo.', NULL, NULL, '2018-06-08 01:31:23', 1, '1', 111, 7, NULL, NULL, NULL, NULL),
	(290, 'Olá sr(a) gabriel de paula , o usuário gabriel de paula  alterou um produto no sistema, irá aparecer na página Moderar Produtos, Atenciosamente Garimpo.', NULL, NULL, '2018-06-08 01:31:23', 1, '436.606.008-65', 111, 7, NULL, NULL, NULL, NULL),
	(291, 'Sr(a) gabriel de paula , seu produto foi aprovado no sistema.', NULL, NULL, '2018-06-08 01:38:43', 1, '436.606.008-65', 111, 5, NULL, NULL, NULL, 1),
	(292, 'Olá sr(a) Administrador, o usuário gabriel de paula  alterou um produto no sistema, irá aparecer na página Moderar Produtos, Atenciosamente Garimpo.', NULL, NULL, '2018-06-08 01:43:41', 1, '1', 111, 7, NULL, NULL, NULL, NULL),
	(293, 'Olá sr(a) gabriel de paula , o usuário gabriel de paula  alterou um produto no sistema, irá aparecer na página Moderar Produtos, Atenciosamente Garimpo.', NULL, NULL, '2018-06-08 01:43:41', 1, '436.606.008-65', 111, 7, NULL, NULL, NULL, NULL),
	(294, 'Sr(a) gabriel de paula , seu produto foi aprovado no sistema.', NULL, NULL, '2018-06-08 01:45:36', 1, '436.606.008-65', 111, 5, NULL, NULL, NULL, 1),
	(295, 'Sr(a) gabriel de paula , seu produto foi aprovado no sistema.', NULL, NULL, '2018-06-08 01:45:36', 1, '436.606.008-65', 111, 5, NULL, NULL, NULL, 1),
	(296, 'Sr(a) gabriel de paula , seu produto foi aprovado no sistema.', NULL, NULL, '2018-06-08 01:45:36', 1, '436.606.008-65', 111, 5, NULL, NULL, NULL, 1),
	(297, 'Olá sr(a) Administrador, o usuário gabriel de paula  alterou um produto no sistema, irá aparecer na página Moderar Produtos, Atenciosamente Garimpo.', NULL, NULL, '2018-06-08 01:47:25', 1, '1', 111, 7, NULL, NULL, NULL, NULL),
	(298, 'Olá sr(a) gabriel de paula , o usuário gabriel de paula  alterou um produto no sistema, irá aparecer na página Moderar Produtos, Atenciosamente Garimpo.', NULL, NULL, '2018-06-08 01:47:25', 1, '436.606.008-65', 111, 7, NULL, NULL, NULL, NULL),
	(299, 'Sr(a) gabriel de paula , seu produto foi aprovado no sistema.', NULL, NULL, '2018-06-08 01:50:02', 1, '436.606.008-65', 111, 5, NULL, NULL, NULL, 1),
	(300, 'Olá sr(a) Administrador, o usuário gabriel de paula  alterou um produto no sistema, irá aparecer na página Moderar Produtos, Atenciosamente Garimpo.', NULL, NULL, '2018-06-08 01:50:33', 1, '1', 111, 7, NULL, NULL, NULL, NULL),
	(301, 'Olá sr(a) gabriel de paula , o usuário gabriel de paula  alterou um produto no sistema, irá aparecer na página Moderar Produtos, Atenciosamente Garimpo.', NULL, NULL, '2018-06-08 01:50:33', 1, '436.606.008-65', 111, 7, NULL, NULL, NULL, NULL),
	(302, 'Sr(a) gabriel de paula , seu produto foi aprovado no sistema.', NULL, NULL, '2018-06-08 13:20:05', 1, '436.606.008-65', 111, 5, NULL, NULL, NULL, 1),
	(303, 'Olá sr(a) gabriel de paula  seu produto recebeu uma denuncia alegando estar com foto irregular, \r\n                            administradores estarão revisando a denúncia e verificando se a denúncia é verídica', NULL, NULL, '2018-06-08 17:54:04', 1, '436.606.008-65', 111, 8, NULL, NULL, NULL, 1),
	(304, 'Olá sr(a) Administrador, este produto recebeu uma denúncia alegando estar com foto irregular ', NULL, NULL, '2018-06-08 17:54:04', 1, '1', 111, 8, NULL, NULL, NULL, NULL),
	(305, 'Olá sr(a) gabriel de paula , este produto recebeu uma denúncia alegando estar com foto irregular ', NULL, NULL, '2018-06-08 17:54:04', 1, '436.606.008-65', 111, 8, NULL, NULL, NULL, NULL),
	(306, 'Olá sr(a) gabriel de paula ,seu produto que havia sido constava erro, pois ele foi desativado, para que ele fique ativo novamente é necessário que arrume-o.', NULL, NULL, '2018-06-08 17:57:16', 1, '436.606.008-65', 105, 1, NULL, NULL, NULL, 1),
	(307, 'Olá sr(a) gabriel de paula ,seu produto que havia sido constava erro, pois ele foi desativado, para que ele fique ativo novamente é necessário que arrume-o.', NULL, NULL, '2018-06-08 17:57:39', 1, '436.606.008-65', 111, 1, NULL, NULL, NULL, 1),
	(308, 'Olá sr(a) Administrador, o usuário gabriel de paula  alterou um produto no sistema, irá aparecer na página Moderar Produtos, Atenciosamente Garimpo.', NULL, NULL, '2018-06-08 17:58:24', 1, '1', 111, 7, NULL, NULL, NULL, NULL),
	(309, 'Olá sr(a) gabriel de paula , o usuário gabriel de paula  alterou um produto no sistema, irá aparecer na página Moderar Produtos, Atenciosamente Garimpo.', NULL, NULL, '2018-06-08 17:58:24', 1, '436.606.008-65', 111, 7, NULL, NULL, NULL, NULL),
	(310, 'Sr(a) gabriel de paula , seu produto foi aprovado no sistema.', NULL, NULL, '2018-06-08 17:59:23', 1, '436.606.008-65', 111, 5, NULL, NULL, NULL, 1),
	(311, 'Olá sr(a) gabriel de paula  seu produto recebeu uma denuncia alegando estar com categoria errada, \r\n                            administradores estarão revisando a denúncia e verificando se a denúncia é verídica', NULL, NULL, '2018-06-08 18:00:46', 1, '436.606.008-65', 111, 8, NULL, NULL, NULL, 1),
	(312, 'Olá sr(a) Administrador, este produto recebeu uma denúncia alegando estar com categoria errada ', NULL, NULL, '2018-06-08 18:00:46', 1, '1', 111, 8, NULL, NULL, NULL, NULL),
	(313, 'Olá sr(a) gabriel de paula , este produto recebeu uma denúncia alegando estar com categoria errada ', NULL, NULL, '2018-06-08 18:00:46', 1, '436.606.008-65', 111, 8, NULL, NULL, NULL, NULL),
	(314, 'Olá sr(a) gabriel de paula ,seu produto que havia sido constava erro, pois ele foi desativado, para que ele fique ativo novamente é necessário que arrume-o.', NULL, NULL, '2018-06-08 18:01:45', 1, '436.606.008-65', 111, 1, NULL, NULL, NULL, 1),
	(315, 'Olá sr(a) gabriel de paula ,seu produto que havia sido constava erro, pois ele foi desativado, para que ele fique ativo novamente é necessário que arrume-o.', NULL, NULL, '2018-06-08 18:01:47', 1, '436.606.008-65', 111, 1, NULL, NULL, NULL, 1),
	(316, 'Olá sr(a) alana campos,seu produto que havia sido constava erro, pois ele foi desativado, para que ele fique ativo novamente é necessário que arrume-o.', NULL, NULL, '2018-06-08 18:01:50', 1, '155.477.841-11', 117, 1, NULL, NULL, NULL, 0),
	(317, 'Sr(a) alana campos, seu produto foi aprovado no sistema.', NULL, NULL, '2018-06-08 18:02:10', 1, '155.477.841-11', 117, 5, NULL, NULL, NULL, 0),
	(318, 'Olá sr(a) antonio almeida,seu produto que havia sido constava erro, pois ele foi desativado, para que ele fique ativo novamente é necessário que arrume-o.', NULL, NULL, '2018-06-08 18:06:44', 1, '216.561.235-55', 114, 1, NULL, NULL, NULL, 1),
	(319, 'Sr(a) gabriel de paula , seu produto foi aprovado no sistema.', NULL, NULL, '2018-06-08 18:06:53', 1, '436.606.008-65', 111, 5, NULL, NULL, NULL, 1),
	(320, 'Sr(a) antonio almeida, seu produto foi aprovado no sistema.', NULL, NULL, '2018-06-08 18:07:32', 1, '216.561.235-55', 114, 5, NULL, NULL, NULL, 1),
	(321, 'Olá sr(a) Administrador, o usuário gabriel de paula  alterou um produto no sistema, irá aparecer na página Moderar Produtos, Atenciosamente Garimpo.', NULL, NULL, '2018-06-08 18:31:27', 1, '1', 111, 7, NULL, NULL, NULL, NULL),
	(322, 'Olá sr(a) gabriel de paula , o usuário gabriel de paula  alterou um produto no sistema, irá aparecer na página Moderar Produtos, Atenciosamente Garimpo.', NULL, NULL, '2018-06-08 18:31:27', 1, '436.606.008-65', 111, 7, NULL, NULL, NULL, NULL),
	(323, 'Sr(a) gabriel de paula , seu produto foi aprovado no sistema.', NULL, NULL, '2018-06-08 18:31:50', 1, '436.606.008-65', 111, 5, NULL, NULL, NULL, 1),
	(324, 'Olá sr(a) Administrador, o usuário gabriel de paula  alterou um produto no sistema, irá aparecer na página Moderar Produtos, Atenciosamente Garimpo.', NULL, NULL, '2018-06-08 18:33:39', 1, '1', 111, 7, NULL, NULL, NULL, NULL),
	(325, 'Olá sr(a) gabriel de paula , o usuário gabriel de paula  alterou um produto no sistema, irá aparecer na página Moderar Produtos, Atenciosamente Garimpo.', NULL, NULL, '2018-06-08 18:33:39', 1, '436.606.008-65', 111, 7, NULL, NULL, NULL, NULL),
	(326, 'Sr(a) gabriel de paula , seu produto foi aprovado no sistema.', NULL, NULL, '2018-06-08 18:33:47', 1, '436.606.008-65', 111, 5, NULL, NULL, NULL, 1),
	(327, 'ta online?\r\n', NULL, NULL, '2018-06-08 23:09:06', 0, '457.897.465-13', 112, 2, '080620180906198', '436.606.008-65', NULL, 1),
	(328, 'Seja muito bem-vindo Sr(a) joao da silva ao Garimpo, aqui você pode vender seus produtos e também comprar novos produtos', NULL, NULL, '2018-06-11 20:36:50', 1, '475.878.548-0', NULL, 1, NULL, NULL, NULL, 1),
	(329, 'Você finalizou o cadastro Sr(a)  no Garimpo, agora você pode comprar e vender', NULL, NULL, '2018-06-11 20:39:46', 1, '475.878.548-0', NULL, 1, NULL, NULL, NULL, 1),
	(330, 'Olá sr(a) joao da silva você efetuou o cadastro do seu produto tenis, agora é só aguardar os administradores aceitarem para que seu produto fique ativo. seu produto cadastrado foi um(a) teniscom1 unidade(s)', NULL, NULL, '2018-06-11 20:48:39', 1, '475.878.548-0', 125, 1, NULL, NULL, NULL, 1),
	(331, 'Olá sr(a) Administrador, o usuário joao da silva inseriu um novo produto no sistema, irá aparecer na página Moderar Produtos, Atenciosamente Garimpo.', NULL, NULL, '2018-06-11 20:48:39', 1, '1', 125, 1, NULL, NULL, NULL, NULL),
	(332, 'Olá sr(a) gabriel de paula , o usuário joao da silva inseriu um novo produto no sistema, irá aparecer na página Moderar Produtos, Atenciosamente Garimpo.', NULL, NULL, '2018-06-11 20:48:39', 1, '436.606.008-65', 125, 1, NULL, NULL, NULL, NULL),
	(333, 'Sr(a) joao da silva, seu produto foi aprovado no sistema.', NULL, NULL, '2018-06-11 20:50:02', 0, '475.878.548-0', 125, 5, NULL, NULL, NULL, 1),
	(334, 'tem na cor vermelha?', NULL, NULL, '2018-06-11 20:52:21', 0, '216.561.235-55', 114, 2, '110620185221320', '1', NULL, 1),
	(335, 'Olá sr(a) gabriel de paula  seu produto recebeu uma denuncia alegando estar com foto irregular, \r\n                            administradores estarão revisando a denúncia e verificando se a denúncia é verídica', NULL, NULL, '2018-06-11 20:58:21', 1, '436.606.008-65', 113, 8, NULL, NULL, NULL, 1),
	(336, 'Olá sr(a) Administrador, este produto recebeu uma denúncia alegando estar com foto irregular ', NULL, NULL, '2018-06-11 20:58:21', 1, '1', 113, 8, NULL, NULL, NULL, NULL),
	(337, 'Olá sr(a) gabriel de paula , este produto recebeu uma denúncia alegando estar com foto irregular ', NULL, NULL, '2018-06-11 20:58:21', 1, '436.606.008-65', 113, 8, NULL, NULL, NULL, NULL),
	(338, 'Olá sr(a) gabriel de paula ,seu produto que havia sido constava erro, pois ele foi desativado, para que ele fique ativo novamente é necessário que arrume-o.', NULL, NULL, '2018-06-11 20:59:10', 1, '436.606.008-65', 113, 1, NULL, NULL, NULL, 1),
	(339, 'Sr(a) gabriel de paula , seu produto foi aprovado no sistema.', NULL, NULL, '2018-06-14 18:04:23', 1, '436.606.008-65', 113, 5, NULL, NULL, NULL, 1),
	(340, 'Olá sr(a) marcelo vidas seu produto recebeu uma denuncia alegando estar com descrição irregular, \r\n                            administradores estarão revisando a denúncia e verificando se a é verídica podendo desativar seu produto.', NULL, NULL, '2018-06-14 18:05:29', 0, '756.475.445-11', 108, 8, NULL, NULL, NULL, 1),
	(341, 'Olá sr(a) Administrador, este produto recebeu uma denúncia alegando estar com descrição irregular ', NULL, NULL, '2018-06-14 18:05:29', 1, '1', 108, 8, NULL, NULL, NULL, NULL),
	(342, 'Olá sr(a) gabriel de paula , este produto recebeu uma denúncia alegando estar com descrição irregular ', NULL, NULL, '2018-06-14 18:05:29', 1, '436.606.008-65', 108, 8, NULL, NULL, NULL, NULL),
	(343, 'Olá sr(a) marcelo vidas seu produto recebeu uma denuncia alegando estar com foto irregular, \r\n                            administradores estarão revisando a denúncia e verificando se a denúncia é verídica', NULL, NULL, '2018-06-14 18:12:14', 0, '756.475.445-11', 108, 8, NULL, NULL, NULL, 1),
	(344, 'Olá sr(a) Administrador, este produto recebeu uma denúncia alegando estar com foto irregular ', NULL, NULL, '2018-06-14 18:12:14', 1, '1', 108, 8, NULL, NULL, NULL, NULL),
	(345, 'Olá sr(a) gabriel de paula , este produto recebeu uma denúncia alegando estar com foto irregular ', NULL, NULL, '2018-06-14 18:12:14', 1, '436.606.008-65', 108, 8, NULL, NULL, NULL, 0),
	(346, 'Olá sr(a) marcelo vidas,seu produto que havia sido denunciado constava erro, pois ele foi desativado, para que ele fique ativo novamente é necessário que arrume-o.', NULL, NULL, '2018-06-14 18:17:22', 0, '756.475.445-11', 108, 1, NULL, NULL, NULL, 1),
	(347, 'Sr(a) marcelo vidas, seu produto foi aprovado no sistema.', NULL, NULL, '2018-06-14 18:17:35', 0, '756.475.445-11', 108, 5, NULL, NULL, NULL, 1),
	(348, 'Olá sr(a) Costa freire seu produto recebeu uma denuncia alegando estar com categoria errada, \r\n                            administradores estarão revisando a denúncia e verificando se a denúncia é verídica', NULL, NULL, '2018-06-14 18:18:00', 0, '457.897.465-13', 112, 8, NULL, NULL, NULL, 1),
	(349, 'Olá sr(a) Administrador, este produto recebeu uma denúncia alegando estar com categoria errada ', NULL, NULL, '2018-06-14 18:18:00', 1, '1', 112, 8, NULL, NULL, NULL, NULL),
	(350, 'Olá sr(a) gabriel de paula , este produto recebeu uma denúncia alegando estar com categoria errada ', NULL, NULL, '2018-06-14 18:18:00', 1, '436.606.008-65', 112, 8, NULL, NULL, NULL, 0),
	(351, 'Olá sr(a) Costa freire,seu produto que havia sido denunciado foi verificado pelos administradores e não consta erro.', NULL, NULL, '2018-06-14 18:19:18', 0, '457.897.465-13', 112, 1, NULL, NULL, NULL, 1),
	(352, 'Seja muito bem-vindo Sr(a) Rafael Santos ao Garimpo, aqui você pode vender seus produtos e também comprar novos produtos', NULL, NULL, '2018-06-15 13:11:59', 1, '121.734.511-11', NULL, 1, NULL, NULL, NULL, 0),
	(353, 'Você finalizou o cadastro Sr(a)  no Garimpo, agora você pode comprar e vender', NULL, NULL, '2018-06-15 13:14:05', 1, '121.734.511-11', NULL, 1, NULL, NULL, NULL, 0),
	(354, 'Seja muito bem-vindo Sr(a) ela moda ao Garimpo, aqui você pode vender seus produtos e também comprar novos produtos', NULL, NULL, '2018-06-17 19:02:16', 0, '218.924.567-22', NULL, 1, NULL, NULL, NULL, 1),
	(355, 'Você finalizou o cadastro Sr(a)  no Garimpo, agora você pode comprar e vender', NULL, NULL, '2018-06-17 19:02:43', 0, '218.924.567-22', NULL, 1, NULL, NULL, NULL, 1),
	(356, 'Sr(a) joao da silva, seu produto foi aprovado no sistema.', NULL, NULL, '2018-06-18 16:17:17', 0, '475.878.548-0', 125, 5, NULL, NULL, NULL, 1),
	(357, 'Olá sr(a) Administrador, o usuário gabriel de paula  alterou um produto no sistema, irá aparecer na página Moderar Produtos, Atenciosamente Garimpo.', NULL, NULL, '2018-06-18 17:29:46', 0, '1', 111, 7, NULL, NULL, NULL, NULL),
	(358, 'Olá sr(a) gabriel de paula , o usuário gabriel de paula  alterou um produto no sistema, irá aparecer na página Moderar Produtos, Atenciosamente Garimpo.', NULL, NULL, '2018-06-18 17:29:46', 1, '436.606.008-65', 111, 7, NULL, NULL, NULL, 0),
	(359, 'Olá sr(a) Administrador, o usuário gabriel de paula  alterou um produto no sistema, irá aparecer na página Moderar Produtos, Atenciosamente Garimpo.', NULL, NULL, '2018-06-18 17:51:36', 0, '1', 111, 7, NULL, NULL, NULL, NULL),
	(360, 'Olá sr(a) gabriel de paula , o usuário gabriel de paula  alterou um produto no sistema, irá aparecer na página Moderar Produtos, Atenciosamente Garimpo.', NULL, NULL, '2018-06-18 17:51:36', 1, '436.606.008-65', 111, 7, NULL, NULL, NULL, 0),
	(361, 'Olá sr(a) Administrador, o usuário gabriel de paula  alterou um produto no sistema, irá aparecer na página Moderar Produtos, Atenciosamente Garimpo.', NULL, NULL, '2018-06-18 17:52:53', 0, '1', 111, 7, NULL, NULL, NULL, NULL),
	(362, 'Olá sr(a) gabriel de paula , o usuário gabriel de paula  alterou um produto no sistema, irá aparecer na página Moderar Produtos, Atenciosamente Garimpo.', NULL, NULL, '2018-06-18 17:52:53', 1, '436.606.008-65', 111, 7, NULL, NULL, NULL, 0),
	(363, 'Olá sr(a) Administrador, o usuário gabriel de paula  alterou um produto no sistema, irá aparecer na página Moderar Produtos, Atenciosamente Garimpo.', NULL, NULL, '2018-06-18 17:54:38', 0, '1', 111, 7, NULL, NULL, NULL, NULL),
	(364, 'Olá sr(a) gabriel de paula , o usuário gabriel de paula  alterou um produto no sistema, irá aparecer na página Moderar Produtos, Atenciosamente Garimpo.', NULL, NULL, '2018-06-18 17:54:38', 1, '436.606.008-65', 111, 7, NULL, NULL, NULL, 0),
	(365, 'Olá sr(a) Administrador, o usuário gabriel de paula  alterou um produto no sistema, irá aparecer na página Moderar Produtos, Atenciosamente Garimpo.', NULL, NULL, '2018-06-18 17:57:53', 0, '1', 111, 7, NULL, NULL, NULL, NULL),
	(366, 'Olá sr(a) gabriel de paula , o usuário gabriel de paula  alterou um produto no sistema, irá aparecer na página Moderar Produtos, Atenciosamente Garimpo.', NULL, NULL, '2018-06-18 17:57:53', 1, '436.606.008-65', 111, 7, NULL, NULL, NULL, 0),
	(367, 'Olá sr(a) Administrador, o usuário gabriel de paula  alterou um produto no sistema, irá aparecer na página Moderar Produtos, Atenciosamente Garimpo.', NULL, NULL, '2018-06-18 18:00:15', 0, '1', 111, 7, NULL, NULL, NULL, NULL),
	(368, 'Olá sr(a) gabriel de paula , o usuário gabriel de paula  alterou um produto no sistema, irá aparecer na página Moderar Produtos, Atenciosamente Garimpo.', NULL, NULL, '2018-06-18 18:00:15', 1, '436.606.008-65', 111, 7, NULL, NULL, NULL, 0),
	(369, 'Olá sr(a) Administrador, o usuário gabriel de paula  alterou um produto no sistema, irá aparecer na página Moderar Produtos, Atenciosamente Garimpo.', NULL, NULL, '2018-06-18 18:02:22', 0, '1', 111, 7, NULL, NULL, NULL, NULL),
	(370, 'Olá sr(a) gabriel de paula , o usuário gabriel de paula  alterou um produto no sistema, irá aparecer na página Moderar Produtos, Atenciosamente Garimpo.', NULL, NULL, '2018-06-18 18:02:22', 1, '436.606.008-65', 111, 7, NULL, NULL, NULL, 0),
	(371, 'Olá sr(a) Administrador, o usuário gabriel de paula  alterou um produto no sistema, irá aparecer na página Moderar Produtos, Atenciosamente Garimpo.', NULL, NULL, '2018-06-18 18:03:45', 0, '1', 111, 7, NULL, NULL, NULL, NULL),
	(372, 'Olá sr(a) gabriel de paula , o usuário gabriel de paula  alterou um produto no sistema, irá aparecer na página Moderar Produtos, Atenciosamente Garimpo.', NULL, NULL, '2018-06-18 18:03:45', 1, '436.606.008-65', 111, 7, NULL, NULL, NULL, 0),
	(373, 'Olá sr(a) Administrador, o usuário gabriel de paula  alterou um produto no sistema, irá aparecer na página Moderar Produtos, Atenciosamente Garimpo.', NULL, NULL, '2018-06-18 18:08:26', 0, '1', 111, 7, NULL, NULL, NULL, NULL),
	(374, 'Olá sr(a) gabriel de paula , o usuário gabriel de paula  alterou um produto no sistema, irá aparecer na página Moderar Produtos, Atenciosamente Garimpo.', NULL, NULL, '2018-06-18 18:08:26', 1, '436.606.008-65', 111, 7, NULL, NULL, NULL, 0),
	(375, 'Olá sr(a) Administrador, o usuário gabriel de paula  alterou um produto no sistema, irá aparecer na página Moderar Produtos, Atenciosamente Garimpo.', NULL, NULL, '2018-06-18 18:19:44', 0, '1', 111, 7, NULL, NULL, NULL, NULL),
	(376, 'Olá sr(a) gabriel de paula , o usuário gabriel de paula  alterou um produto no sistema, irá aparecer na página Moderar Produtos, Atenciosamente Garimpo.', NULL, NULL, '2018-06-18 18:19:44', 1, '436.606.008-65', 111, 7, NULL, NULL, NULL, 0),
	(377, 'Olá sr(a) Administrador, o usuário gabriel de paula  alterou um produto no sistema, irá aparecer na página Moderar Produtos, Atenciosamente Garimpo.', NULL, NULL, '2018-06-18 20:26:18', 0, '1', 111, 7, NULL, NULL, NULL, NULL),
	(378, 'Olá sr(a) gabriel de paula , o usuário gabriel de paula  alterou um produto no sistema, irá aparecer na página Moderar Produtos, Atenciosamente Garimpo.', NULL, NULL, '2018-06-18 20:26:18', 1, '436.606.008-65', 111, 7, NULL, NULL, NULL, 0),
	(379, 'Sr(a) gabriel de paula , seu produto não foi aprovado no sistema, modifique-o para uma nova moderação', NULL, NULL, '2018-06-18 22:48:36', 1, '436.606.008-65', 111, 6, NULL, NULL, NULL, 0),
	(380, 'Olá sr(a) gabriel de paula  você efetuou o cadastro do seu produto Camisa Batman, agora é só aguardar os administradores aceitarem para que seu produto fique ativo. seu produto cadastrado foi um(a) Camisa Batmancom6 unidade(s)', NULL, NULL, '2018-06-19 20:14:20', 1, '436.606.008-65', 126, 1, NULL, NULL, NULL, 1),
	(381, 'Olá sr(a) Administrador, o usuário gabriel de paula  inseriu um novo produto no sistema, irá aparecer na página Moderar Produtos, Atenciosamente Garimpo.', NULL, NULL, '2018-06-19 20:14:20', 0, '1', 126, 1, NULL, NULL, NULL, NULL),
	(382, 'Olá sr(a) gabriel de paula , o usuário gabriel de paula  inseriu um novo produto no sistema, irá aparecer na página Moderar Produtos, Atenciosamente Garimpo.', NULL, NULL, '2018-06-19 20:14:20', 1, '436.606.008-65', 126, 1, NULL, NULL, NULL, NULL),
	(383, 'Sr(a) gabriel de paula , seu produto foi aprovado no sistema.', NULL, NULL, '2018-06-19 20:25:46', 1, '436.606.008-65', 126, 5, NULL, NULL, NULL, 1);
/*!40000 ALTER TABLE `men_mensagens` ENABLE KEYS */;

-- Copiando estrutura para tabela garimpao.pro_produtos
CREATE TABLE IF NOT EXISTS `pro_produtos` (
  `pro_codigo` int(11) NOT NULL AUTO_INCREMENT,
  `pro_nome` varchar(80) NOT NULL,
  `pro_descricao` varchar(255) NOT NULL,
  `pro_condicao` varchar(30) NOT NULL,
  `pro_preco` double(16,2) NOT NULL,
  `pro_preco_antigo` double(16,2) DEFAULT NULL,
  `pro_peso` double DEFAULT NULL,
  `pro_medida` char(10) DEFAULT NULL,
  `pro_quantidade` int(11) NOT NULL,
  `pro_status` tinyint(1) NOT NULL,
  `pro_moderacao_status` int(10) DEFAULT NULL,
  `pro_acesso` int(255) DEFAULT NULL,
  `usu_cpf_cnpj` char(20) NOT NULL,
  `mar_codigo` int(11) NOT NULL,
  `sub_codigo` int(11) NOT NULL,
  PRIMARY KEY (`pro_codigo`),
  KEY `usu_cpf` (`usu_cpf_cnpj`),
  KEY `mar_codigo` (`mar_codigo`),
  KEY `sub_codigo` (`sub_codigo`),
  CONSTRAINT `pro_produtos_ibfk_1` FOREIGN KEY (`usu_cpf_cnpj`) REFERENCES `usu_usuarios` (`usu_cpf_cnpj`),
  CONSTRAINT `pro_produtos_ibfk_2` FOREIGN KEY (`mar_codigo`) REFERENCES `mar_marcas` (`mar_codigo`),
  CONSTRAINT `pro_produtos_ibfk_3` FOREIGN KEY (`sub_codigo`) REFERENCES `sub_subcategorias` (`sub_codigo`)
) ENGINE=InnoDB AUTO_INCREMENT=127 DEFAULT CHARSET=utf8;

-- Copiando dados para a tabela garimpao.pro_produtos: ~21 rows (aproximadamente)
DELETE FROM `pro_produtos`;
/*!40000 ALTER TABLE `pro_produtos` DISABLE KEYS */;
INSERT INTO `pro_produtos` (`pro_codigo`, `pro_nome`, `pro_descricao`, `pro_condicao`, `pro_preco`, `pro_preco_antigo`, `pro_peso`, `pro_medida`, `pro_quantidade`, `pro_status`, `pro_moderacao_status`, `pro_acesso`, `usu_cpf_cnpj`, `mar_codigo`, `sub_codigo`) VALUES
	(105, 'Camisa do Guns N\' Roses', 'regata cavada com franja, estampa guns n roses.\r\nmaterial: algodão e poliéster.\r\nfico a disposição para mais informações!', 'novo', 15.00, 30.00, NULL, 'P', 1, 1, 1, 54, '436.606.008-65', 54, 79),
	(106, 'geek girly', 'camiseta "geek" com costura na dobra da manga', 'novo', 20.00, 45.00, NULL, 'M', 1, 1, 1, 96, '436.606.008-65', 54, 72),
	(108, 'cropped amarelo geek', 'camiseta cropped amarela\r\ntamanho g, mas pode ser usada como oversize', 'novo', 100.00, 99.00, NULL, 'M', 1, 1, 1, 104, '756.475.445-11', 55, 72),
	(109, 'All Star superman', 'converse all star original de cano alto\r\nusado pouquíssimas vezes (2 pra ser exata)\r\nmodelo chuck taylor de tecido todo coloridão \r\noficial da dc comics superman\r\nedição limitada\r\ntamanho: 7 (fem. usa) equivalente ao 36 bra\r\n24 cm de comprimento', 'usado', 60.00, 50.00, NULL, '36', 1, 1, 1, 21, '445.687.874-51', 56, 93),
	(110, ' Tênis para Gamers e Geeks', 'ande com o tênis do seu jogo favorito.', 'novo', 0.00, 0.00, NULL, '35', 1, 1, 1, 10, '445.687.874-51', 50, 93),
	(111, 'ALTERANDO', 'Essa é a descrição alterada', 'novo', 12.00, 12.00, NULL, '', 1, 0, 2, 26, '436.606.008-65', 33, 77),
	(112, 'Camisa Star Wars Darth Vader', 'Malha 100% poliéster com toque de algodão, muito confortável e leve.\r\nEstampa digital de alta durabilidade, com cores vivas e imagens em alta resolução.\r\nÉ possível colocar em máquina de lavar e passar ferro quente sobre a estampa até 40º c.', 'novo', 50.00, 0.00, NULL, 'G', 4, 1, 1, 216, '457.897.465-13', 57, 72),
	(113, 'Call Of Duty - Black Ops ', 'Malha 100% poliéster com toque de algodão, muito confortável e leve.\r\nEstampa digital de alta durabilidade, com cores vivas e imagens em alta resolução.\r\nÉ possível colocar em máquina de lavar e passar ferro quente sobre a estampa até 40º c.', 'novo', 40.00, 0.00, NULL, 'M', 8, 1, 1, 151, '436.606.008-65', 57, 151),
	(114, 'Caneca Darth Vader Star Wars ', 'A caneca que aliada ao lado negro do seu café vai te dar toda força necessaria para o dia todo!\r\n', 'novo', 36.90, 45.50, NULL, '', 7, 1, 1, 211, '216.561.235-55', 58, 311),
	(115, 'Tênis Sonic', 'Sensação natural e energizada a partir do momento em que você pisar pela primeira vez é o que este calçado oferece.', 'novo', 190.00, 0.00, NULL, '37', 1, 1, 1, 10, '436.606.008-65', 50, 165),
	(116, 'caneca Magica 3d ', 'Numa galaxia distancia na transição da República ao Império , Anakin Skywalker foi para o lado negro da Força. ', 'novo', 49.00, 0.00, NULL, '', 9, 1, 1, 11, '155.477.841-11', 33, 311),
	(117, 'Camisa de programador', 'Camiseta 100% poliéster\r\nEstampa sublimada\r\nNão descasca, não desbota\r\nMalha de ótima qualidade\r\nCor da camiseta: BRANCA ou CINZA', 'novo', 29.99, 50.99, NULL, 'G', 10, 1, 1, 26, '155.477.841-11', 54, 151),
	(118, 'Camiseta Guns N\' Roses ', 'Camiseta 100% poliéster\r\nEstampa sublimada\r\nNão descasca, não desbota\r\nMalha de ótima qualidade', 'novo', 46.99, 75.00, NULL, 'M', 6, 1, 1, 6, '155.477.841-11', 54, 79),
	(119, 'Caneca Guns N\' Roses', 'Material: Porcelana preta resinada classe AAA (Perfeição e alto brilho); \r\nDimensões da caneca: 8C x 10L x 9,5A; \r\nCapacidade: 325ml; \r\nImpressão: Impressão digital sublimática permanente;', 'novo', 39.99, 0.00, NULL, '', 8, 1, 1, 4, '126.782.342-31', 54, 310),
	(120, 'Tenis Guns N\' Roses', 'TÊNIS GUNS N\' ROSES CANO ALTO TAMANHO 44 PRETO COM ESTAMPAS DOS LADOS E "G N\' R" COSTURADO NA PARTE DE TRÁS', 'novo', 100.00, 0.00, NULL, '44', 1, 1, 1, 2, '126.782.342-31', 54, 262),
	(121, 'Bolsa Slipknot', '18” Medidas: 32 cm de comprimento 42 cm de altura e 16 cm de profundidade Composição: 95%poliéster / 5% PVC PRETO', 'novo', 99.99, 0.00, NULL, '', 5, 1, 1, 6, '126.782.342-31', 60, 264),
	(122, 'Bolsa Metallica', 'BOLSA SACOLA TIRACOLO\r\nBRIM 100%ALGODÃO DUBLADO\r\nFORRO EM MICRO FIBRA\r\nESTAMPA SILK SCREEN\r\nCOM FECHO CENTRAL BOTÃO DE PRESSÃO', 'novo', 64.99, 0.00, NULL, '', 1, 1, 1, 4, '126.782.342-31', 61, 263),
	(123, 'Relógio De Pulso Hard Rock', 'Relógio Personalizado Logo Banda de Rock AC DC\r\nBateria Original Sony Made In Japan\r\nMecanismo: O relógio e dotado de um mecanismo denominado MIYOTA. Sendo este parte integrante de modelos famosos como Citizen.', 'novo', 250.05, 0.00, NULL, '', 1, 1, 1, 3, '125.661.223-55', 54, 247),
	(124, 'Bolsa me mine', 'Bolsa Para Colorir Color Me Mine Hipster da Dtc É Ideal Para Meninas Acima de 6 Anos.\r\nbolsa Para Pintar Como Quiser! Deixe a Tinta Secar e Depois É Só Usar a Bolsa com Um Superlook Todo Seu!\r\nacompanha 5 Canetas Permanentes Coloridas. ', 'novo', 59.99, 0.00, NULL, '', 10, 1, 1, 3, '125.661.223-55', 54, 125),
	(125, 'tenis', 'tesnis de joga bola', 'usado', 1000.00, 0.00, NULL, '', 1, 1, 1, 1, '475.878.548-0', 62, 103),
	(126, 'Camisa Batman', 'Use sua camisa favorita do batman, excelente qualidade do tecido', 'novo', 150.00, 0.00, NULL, 'PP', 6, 1, 1, 0, '436.606.008-65', 46, 72);
/*!40000 ALTER TABLE `pro_produtos` ENABLE KEYS */;

-- Copiando estrutura para tabela garimpao.sub_subcategorias
CREATE TABLE IF NOT EXISTS `sub_subcategorias` (
  `sub_codigo` int(11) NOT NULL AUTO_INCREMENT,
  `sub_nome` varchar(20) NOT NULL,
  `sub_figura` varchar(255) DEFAULT NULL,
  `cat_codigo` int(11) NOT NULL,
  PRIMARY KEY (`sub_codigo`),
  KEY `cat_codigo` (`cat_codigo`),
  CONSTRAINT `sub_subcategorias_ibfk_1` FOREIGN KEY (`cat_codigo`) REFERENCES `cat_categorias` (`cat_codigo`)
) ENGINE=InnoDB AUTO_INCREMENT=313 DEFAULT CHARSET=utf8;

-- Copiando dados para a tabela garimpao.sub_subcategorias: ~288 rows (aproximadamente)
DELETE FROM `sub_subcategorias`;
/*!40000 ALTER TABLE `sub_subcategorias` DISABLE KEYS */;
INSERT INTO `sub_subcategorias` (`sub_codigo`, `sub_nome`, `sub_figura`, `cat_codigo`) VALUES
	(25, 'Óculos', NULL, 18),
	(26, 'Relógio', NULL, 18),
	(27, 'Bjoux', NULL, 18),
	(28, 'Cintos', NULL, 18),
	(29, 'Joias', NULL, 18),
	(30, 'Chapeus', NULL, 18),
	(31, 'Meia calça', NULL, 18),
	(32, 'Blusas', NULL, 19),
	(33, 'Calças', NULL, 19),
	(34, 'Camisas', NULL, 19),
	(35, 'Casacos', NULL, 19),
	(36, 'Saias', NULL, 19),
	(37, 'Shorts', NULL, 19),
	(38, 'Vestidos', NULL, 19),
	(39, 'Perfumes', NULL, 20),
	(40, 'Maquiagem', NULL, 20),
	(41, 'Cosméticos', NULL, 20),
	(42, 'Unas', NULL, 20),
	(43, 'Cabelos', NULL, 20),
	(44, 'Botas', NULL, 21),
	(45, 'Sandálias', NULL, 21),
	(46, 'Sapatilhas', NULL, 21),
	(47, 'Sapatos', NULL, 21),
	(48, 'Tênis', NULL, 21),
	(49, 'Vestido de renda', NULL, 24),
	(50, 'Vestido princesa', NULL, 24),
	(51, 'Vestido cauda longa', NULL, 24),
	(52, 'Buque', NULL, 24),
	(53, 'Frente única', NULL, 23),
	(54, 'Tomara que caia', NULL, 23),
	(55, 'Meia-taça', NULL, 23),
	(56, 'Push-up', NULL, 23),
	(57, 'Blusas', NULL, 19),
	(58, 'Calças', NULL, 19),
	(59, 'Camisas', NULL, 19),
	(60, 'Casacos', NULL, 19),
	(61, 'Saias', NULL, 19),
	(62, 'Shorts', NULL, 19),
	(63, 'Vestidos', NULL, 19),
	(64, 'Óculos ', NULL, 25),
	(65, 'Relógio', NULL, 25),
	(66, 'Bjoux', NULL, 25),
	(67, 'Joias', NULL, 25),
	(68, 'Chapeus', NULL, 25),
	(69, 'Meia Calça', NULL, 25),
	(70, 'Blusas', NULL, 26),
	(71, 'Calças', NULL, 26),
	(72, 'Camisas', NULL, 26),
	(73, 'Casacos', NULL, 26),
	(74, 'Saias', NULL, 26),
	(75, 'Shorts', NULL, 26),
	(76, 'Vestidos', NULL, 26),
	(77, 'Blusas', NULL, 61),
	(78, 'Calças', NULL, 61),
	(79, 'Camisas', NULL, 61),
	(80, 'Casacos', NULL, 61),
	(81, 'Saias', NULL, 61),
	(82, 'Shorts', NULL, 61),
	(83, 'Vestidos', NULL, 61),
	(84, 'Perfumes', NULL, 27),
	(85, 'Maquiagem', NULL, 27),
	(86, 'Cosméticos', NULL, 27),
	(87, 'Unas', NULL, 27),
	(88, 'Cabelos', NULL, 27),
	(89, 'Botas', NULL, 28),
	(90, 'Sandálias', NULL, 28),
	(91, 'Sapatilhas', NULL, 28),
	(92, 'Sapatos', NULL, 28),
	(93, 'Tênis', NULL, 28),
	(94, 'Ombro', NULL, 29),
	(95, 'Mochila', NULL, 29),
	(96, 'De mão', NULL, 29),
	(97, 'Necessaire', NULL, 29),
	(98, 'Frente única', NULL, 30),
	(99, 'Tomara que caia', NULL, 30),
	(100, 'Meia-taça', NULL, 30),
	(101, 'Push-up', NULL, 30),
	(102, 'Vestido renda', NULL, 31),
	(103, 'Vestido princesa', NULL, 31),
	(104, 'Vestido cauda longa', NULL, 31),
	(105, 'Buquê', NULL, 31),
	(106, 'Óculos', NULL, 32),
	(107, 'Relógio', NULL, 32),
	(108, 'Bjoux', NULL, 32),
	(109, 'Cintos', NULL, 32),
	(110, 'Chapéus', NULL, 32),
	(111, 'Joias', NULL, 32),
	(112, 'Meia calça', NULL, 32),
	(113, 'Blusas', NULL, 33),
	(114, 'Calças', NULL, 33),
	(115, 'Camisas', NULL, 33),
	(116, 'Casacos', NULL, 33),
	(117, 'Sais', NULL, 33),
	(118, 'Shorts', NULL, 33),
	(119, 'Vestidos', NULL, 33),
	(120, 'Perfumes', NULL, 34),
	(121, 'Maquiagem', NULL, 34),
	(122, 'Cosméticos', NULL, 34),
	(123, 'Únas', NULL, 34),
	(124, 'Cabelos', NULL, 34),
	(125, 'Ombro', NULL, 36),
	(126, 'Mochila', NULL, 36),
	(127, 'De mão', NULL, 36),
	(128, 'Necessaire', NULL, 36),
	(129, 'Frente única', NULL, 37),
	(130, 'Tomara que caia', NULL, 37),
	(131, 'Meia-taça', NULL, 37),
	(132, 'Pushup', NULL, 37),
	(133, 'Vestido renda', NULL, 38),
	(134, 'Vestido princesa', NULL, 38),
	(135, 'Vestido cauda longa', NULL, 38),
	(136, 'Buquê', NULL, 38),
	(137, 'Botas', NULL, 35),
	(138, 'Sandálias', NULL, 35),
	(139, 'Sapatilhas', NULL, 35),
	(140, 'Sapatos', NULL, 35),
	(141, 'Tênis', NULL, 35),
	(142, 'Óculos', NULL, 39),
	(143, 'Relógio', NULL, 39),
	(144, 'Bjoux', NULL, 39),
	(145, 'Cintos', NULL, 39),
	(146, 'Joias', NULL, 39),
	(147, 'Chapéus', NULL, 39),
	(148, 'Meia calça', NULL, 39),
	(149, 'Blusas', NULL, 40),
	(150, 'Calças', NULL, 40),
	(151, 'Camisas', NULL, 40),
	(152, 'Casacos', NULL, 40),
	(153, 'Saias', NULL, 40),
	(154, 'Shorts', NULL, 40),
	(155, 'Vestidos', NULL, 40),
	(156, 'Perfumes', NULL, 41),
	(157, 'Maquiagem', NULL, 41),
	(158, 'Cosméticos', NULL, 41),
	(159, 'Únas', NULL, 41),
	(160, 'Cabelos', NULL, 41),
	(161, 'Botas', NULL, 42),
	(162, 'Sandálias', NULL, 42),
	(163, 'Sapatilhas', NULL, 42),
	(164, 'Sapatos', NULL, 42),
	(165, 'Tênis', NULL, 42),
	(166, 'Ombro', NULL, 43),
	(167, 'Mochila', NULL, 43),
	(168, 'de Mão', NULL, 43),
	(169, 'Necessaire', NULL, 43),
	(170, 'Frente única', NULL, 44),
	(171, 'Tomara que caia', NULL, 44),
	(172, 'Meia-taça', NULL, 44),
	(173, 'Push-up', NULL, 44),
	(174, 'Óculos', NULL, 46),
	(175, 'Relógio', NULL, 46),
	(176, 'Bjoux', NULL, 46),
	(177, 'Cintos', NULL, 46),
	(178, 'Joias', NULL, 46),
	(179, 'Chapéus', NULL, 46),
	(180, 'Meia-calça', NULL, 46),
	(181, 'Blusas', NULL, 47),
	(182, 'Calças', NULL, 47),
	(183, 'Camisas', NULL, 47),
	(184, 'Casacos', NULL, 47),
	(185, 'Saias', NULL, 47),
	(186, 'Shorts', NULL, 47),
	(187, 'Vestidos', NULL, 47),
	(188, 'Perfumes', NULL, 48),
	(189, 'Maquiagem', NULL, 48),
	(190, 'Cosméticos', NULL, 48),
	(191, 'Únas', NULL, 48),
	(192, 'Cabelos', NULL, 48),
	(193, 'Botas', NULL, 49),
	(194, 'Sandálias', NULL, 49),
	(195, 'Sapatilhas', NULL, 49),
	(196, 'Sapatos', NULL, 49),
	(197, 'Tênis', NULL, 49),
	(198, 'Ombro', NULL, 50),
	(199, 'Mochila', NULL, 50),
	(200, 'De mão', NULL, 50),
	(201, 'Necessaire', NULL, 50),
	(202, 'Frente única', NULL, 51),
	(203, 'Tomara que caia', NULL, 51),
	(204, 'Meia-taca', NULL, 51),
	(205, 'Push-up', NULL, 51),
	(206, 'Vestido renda', NULL, 52),
	(207, 'Vestido princesa', NULL, 52),
	(208, 'Vestido cauda longa', NULL, 52),
	(209, 'Buquê', NULL, 52),
	(210, 'Óculos', NULL, 53),
	(211, 'Relógio', NULL, 53),
	(212, 'Bjoux', NULL, 53),
	(213, 'Cintos', NULL, 53),
	(214, 'Joias', NULL, 53),
	(215, 'Chapéus', NULL, 53),
	(216, 'Meia calça', NULL, 53),
	(217, 'Blusas', NULL, 54),
	(218, 'Calças', NULL, 54),
	(219, 'Camisas', NULL, 54),
	(220, 'Casacos', NULL, 54),
	(221, 'Saias', NULL, 54),
	(222, 'Shorts', NULL, 54),
	(223, 'Vestidos', NULL, 54),
	(224, 'Perfumes', NULL, 55),
	(225, 'Maquiagem', NULL, 55),
	(226, 'Cosméticos', NULL, 55),
	(227, 'Únas', NULL, 55),
	(228, 'Cabelos', NULL, 55),
	(229, 'Botas', NULL, 56),
	(230, 'Sandálias', NULL, 56),
	(231, 'Sapatilhas', NULL, 56),
	(232, 'Sapatos', NULL, 56),
	(233, 'Tênis', NULL, 56),
	(234, 'Ombro', NULL, 57),
	(235, 'Mochila', NULL, 57),
	(236, 'De mão', NULL, 57),
	(237, 'Necessaire', NULL, 57),
	(238, 'Frente única', NULL, 58),
	(239, 'Tomara que caia', NULL, 58),
	(240, 'Meia-taça', NULL, 58),
	(241, 'Push-up', NULL, 58),
	(242, 'Vestido renda', NULL, 59),
	(243, 'Vestido princesa', NULL, 59),
	(244, 'Vestido cauda longa', NULL, 59),
	(245, 'Buquê', NULL, 59),
	(246, 'Óculos', NULL, 60),
	(247, 'Relógio', NULL, 60),
	(248, 'Bjoux', NULL, 60),
	(249, 'Cintos', NULL, 60),
	(250, 'Joias', NULL, 60),
	(251, 'Chapéus', NULL, 60),
	(252, 'Meia-calça', NULL, 60),
	(253, 'Perfumes', NULL, 62),
	(254, 'Maquiagem', NULL, 62),
	(255, 'Cosméticos', NULL, 62),
	(256, 'Únas', NULL, 62),
	(257, 'Cabelos', NULL, 62),
	(258, 'Botas', NULL, 63),
	(259, 'Sandálias', NULL, 63),
	(260, 'Sapatilhas', NULL, 63),
	(261, 'Sapatos', NULL, 63),
	(262, 'Tênis', NULL, 63),
	(263, 'Ombro', NULL, 64),
	(264, 'Mochila', NULL, 64),
	(265, 'De mão', NULL, 64),
	(266, 'Necessaire', NULL, 64),
	(267, 'Frente única', NULL, 65),
	(268, 'Tomara que caia', NULL, 65),
	(269, 'Meia-taça', NULL, 65),
	(270, 'Push-up', NULL, 65),
	(271, 'Vestido renda', NULL, 66),
	(272, 'Vestido princesa', NULL, 66),
	(273, 'Vestido cauda longa', NULL, 66),
	(274, 'Buquê', NULL, 66),
	(275, 'Óculos', NULL, 67),
	(276, 'Relógio', NULL, 67),
	(277, 'Bjoux', NULL, 67),
	(278, 'Cintos', NULL, 67),
	(279, 'Chapéus', NULL, 67),
	(280, 'Meia calça', NULL, 67),
	(281, 'Blusas', NULL, 68),
	(282, 'Calças', NULL, 68),
	(283, 'Camisas', NULL, 68),
	(284, 'Casacos', NULL, 68),
	(285, 'Saias', NULL, 68),
	(286, 'Vestidos', NULL, 68),
	(287, 'Perfumes', NULL, 69),
	(288, 'Maquiagem', NULL, 69),
	(289, 'Cosméticos', NULL, 69),
	(290, 'Únas', NULL, 69),
	(291, 'Cabelos', NULL, 69),
	(292, 'Botas', NULL, 70),
	(293, 'Sandálias', NULL, 70),
	(294, 'Sapatilhas', NULL, 70),
	(295, 'Sapatos', NULL, 70),
	(296, 'Tênis', NULL, 70),
	(297, 'Ombro', NULL, 71),
	(298, 'Mochila', NULL, 71),
	(299, 'De mão', NULL, 71),
	(300, 'Necessaire', NULL, 71),
	(301, 'Frente única', NULL, 72),
	(302, 'Tomara que caia', NULL, 72),
	(303, 'Meia-taça', NULL, 72),
	(304, 'Push-up', NULL, 72),
	(305, 'Vestido renda', NULL, 73),
	(306, 'Vestido princesa', NULL, 73),
	(307, 'Vestido cauda longa', NULL, 73),
	(308, 'Buquê', NULL, 73),
	(309, 'Caneca', NULL, 25),
	(310, 'Caneca', NULL, 60),
	(311, 'Caneca', NULL, 39),
	(312, 'Cintos', NULL, 25);
/*!40000 ALTER TABLE `sub_subcategorias` ENABLE KEYS */;

-- Copiando estrutura para tabela garimpao.tip_tipo
CREATE TABLE IF NOT EXISTS `tip_tipo` (
  `tip_codigo` int(11) NOT NULL AUTO_INCREMENT,
  `tip_nome_tipo` varchar(45) NOT NULL,
  PRIMARY KEY (`tip_codigo`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;

-- Copiando dados para a tabela garimpao.tip_tipo: ~2 rows (aproximadamente)
DELETE FROM `tip_tipo`;
/*!40000 ALTER TABLE `tip_tipo` DISABLE KEYS */;
INSERT INTO `tip_tipo` (`tip_codigo`, `tip_nome_tipo`) VALUES
	(1, 'Administrador'),
	(2, 'Usuário');
/*!40000 ALTER TABLE `tip_tipo` ENABLE KEYS */;

-- Copiando estrutura para tabela garimpao.tme_tipo_mensagens
CREATE TABLE IF NOT EXISTS `tme_tipo_mensagens` (
  `tme_codigo` int(11) NOT NULL AUTO_INCREMENT,
  `tme_nome_tipo` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`tme_codigo`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8;

-- Copiando dados para a tabela garimpao.tme_tipo_mensagens: ~8 rows (aproximadamente)
DELETE FROM `tme_tipo_mensagens`;
/*!40000 ALTER TABLE `tme_tipo_mensagens` DISABLE KEYS */;
INSERT INTO `tme_tipo_mensagens` (`tme_codigo`, `tme_nome_tipo`) VALUES
	(1, 'Equipe Garimpo'),
	(2, 'Pergunta sobre produto'),
	(3, 'Resposta sobre produto'),
	(4, 'Produto atualizado'),
	(5, 'Produto aprovado'),
	(6, 'Produto recusado'),
	(7, 'Produdo alterado'),
	(8, 'Denúncia de Produto');
/*!40000 ALTER TABLE `tme_tipo_mensagens` ENABLE KEYS */;

-- Copiando estrutura para tabela garimpao.usu_usuarios
CREATE TABLE IF NOT EXISTS `usu_usuarios` (
  `usu_cpf_cnpj` char(20) NOT NULL,
  `usu_nome` varchar(80) NOT NULL,
  `usu_sexo` char(1) DEFAULT NULL,
  `usu_data_nasc` date DEFAULT NULL,
  `usu_email` varchar(80) NOT NULL,
  `usu_senha` varchar(255) NOT NULL,
  `usu_telefone` char(14) DEFAULT NULL,
  `usu_data_cadastro` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `usu_status_cadastro` tinyint(1) NOT NULL,
  `usu_foto_perfil` varchar(255) DEFAULT NULL,
  `usu_nome_loja` varchar(40) DEFAULT NULL,
  `usu_qtdd_vendas` int(11) DEFAULT NULL,
  `usu_qtdd_vendas_canceladas` int(11) DEFAULT NULL,
  `usu_qtdd_denuncia` int(11) DEFAULT NULL,
  `usu_qtdd_compras` int(11) DEFAULT NULL,
  `usu_qtdd_compras_canceladas` int(11) DEFAULT NULL,
  `usu_medida_busto` varchar(10) DEFAULT NULL,
  `usu_medida_cintura` varchar(10) DEFAULT NULL,
  `usu_medida_calcado` varchar(10) DEFAULT NULL,
  `usu_reputacao` double DEFAULT NULL,
  `usu_cadastroCompleto` int(2) DEFAULT NULL,
  `usu_tentativas` int(11) DEFAULT NULL,
  `tip_codigo` int(11) DEFAULT NULL,
  `sub_codigo` int(11) DEFAULT NULL,
  PRIMARY KEY (`usu_cpf_cnpj`),
  UNIQUE KEY `usu_cpf_cnpj_UNIQUE` (`usu_cpf_cnpj`),
  UNIQUE KEY `usu_email_UNIQUE` (`usu_email`),
  UNIQUE KEY `usu_telefone_UNIQUE` (`usu_telefone`),
  KEY `tip_codigo` (`tip_codigo`),
  KEY `sub_codigo` (`sub_codigo`),
  CONSTRAINT `sub_codigo` FOREIGN KEY (`sub_codigo`) REFERENCES `sub_subcategorias` (`sub_codigo`),
  CONSTRAINT `usu_usuarios_ibfk_1` FOREIGN KEY (`tip_codigo`) REFERENCES `tip_tipo` (`tip_codigo`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- Copiando dados para a tabela garimpao.usu_usuarios: ~14 rows (aproximadamente)
DELETE FROM `usu_usuarios`;
/*!40000 ALTER TABLE `usu_usuarios` DISABLE KEYS */;
INSERT INTO `usu_usuarios` (`usu_cpf_cnpj`, `usu_nome`, `usu_sexo`, `usu_data_nasc`, `usu_email`, `usu_senha`, `usu_telefone`, `usu_data_cadastro`, `usu_status_cadastro`, `usu_foto_perfil`, `usu_nome_loja`, `usu_qtdd_vendas`, `usu_qtdd_vendas_canceladas`, `usu_qtdd_denuncia`, `usu_qtdd_compras`, `usu_qtdd_compras_canceladas`, `usu_medida_busto`, `usu_medida_cintura`, `usu_medida_calcado`, `usu_reputacao`, `usu_cadastroCompleto`, `usu_tentativas`, `tip_codigo`, `sub_codigo`) VALUES
	('1', 'Administrador', 'M', '1995-06-16', 'adm@adm', 'c7d39eb8076cddec95735db4e0e094d3c4be197a0f885cbb514177b1017e056f87236d001b4c817df7ee17838d90910cb34134c9056a2937422aa6775f8c601c', '(11) 4211-4124', '2018-03-31 01:14:30', 1, '\\FotosPerfis\\usuarios\\1\\1-Administrador.jpg', 'Lojinha do(a)Administrador', 0, 0, 0, 0, 0, '', '', '', 0, 2, 0, 1, 72),
	('111.256.734-54', 'teste alterar', 'M', '1995-06-16', 'teste@teste', 'c7d39eb8076cddec95735db4e0e094d3c4be197a0f885cbb514177b1017e056f87236d001b4c817df7ee17838d90910cb34134c9056a2937422aa6775f8c601c', '(49) 8741-2123', '2018-05-26 04:11:26', 1, '../../themes/images/FOTOPERFIL/este.gif', 'Lojinha do(a)teste alterar', 0, 0, 0, 0, 0, '', '', '', 0, 2, 0, 2, 25),
	('121.734.511-11', 'Rafael Santos', 'M', '1989-05-20', 'rafael@gmail.com', 'c7d39eb8076cddec95735db4e0e094d3c4be197a0f885cbb514177b1017e056f87236d001b4c817df7ee17838d90910cb34134c9056a2937422aa6775f8c601c', '(45) 4565-4645', '2018-06-15 13:11:59', 1, '\\FotosPerfis\\usuarios\\121.734.511-11\\150620181401103.jpg', 'Lojinha do(a)Rafael Santos', 0, 0, 0, 0, 0, '', '', '', 0, 2, 0, 2, 25),
	('125.661.223-55', 'sandra maria', 'F', '1991-07-18', 'sandra@hardrock', 'c7d39eb8076cddec95735db4e0e094d3c4be197a0f885cbb514177b1017e056f87236d001b4c817df7ee17838d90910cb34134c9056a2937422aa6775f8c601c', '(51) 5487-7877', '2018-05-27 02:56:38', 1, '\\FotosPerfis\\usuarios\\125.661.223-55\\270520185805442.jpg', 'Lojinha do(a)sandra maria', 0, 0, 0, 0, 0, '', '', '', 0, 2, 0, 2, 72),
	('126.782.342-31', 'joana Krat', 'F', '1985-07-10', 'joana@rock', 'c7d39eb8076cddec95735db4e0e094d3c4be197a0f885cbb514177b1017e056f87236d001b4c817df7ee17838d90910cb34134c9056a2937422aa6775f8c601c', '(71) 5648-7877', '2018-05-26 16:29:33', 1, '\\FotosPerfis\\usuarios\\126.782.342-31\\260520183123831.jpg', 'Lojinha do(a)joana Krat', 0, 0, 0, 0, 0, '', '', '', 0, 2, 0, 2, 311),
	('155.477.841-11', 'alana campos', 'F', '1997-06-16', 'alana@geek', 'c7d39eb8076cddec95735db4e0e094d3c4be197a0f885cbb514177b1017e056f87236d001b4c817df7ee17838d90910cb34134c9056a2937422aa6775f8c601c', '(31) 5468-7454', '2018-05-26 15:07:43', 1, '\\FotosPerfis\\usuarios\\155.477.841-11\\260520180837514.jpg', 'Lojinha do(a)alana campos', 0, 0, 0, 0, 0, '', '', '', 0, 2, 0, 2, 151),
	('216.561.235-55', 'antonio almeida', 'M', '1984-05-14', 'geek@almeida', 'c7d39eb8076cddec95735db4e0e094d3c4be197a0f885cbb514177b1017e056f87236d001b4c817df7ee17838d90910cb34134c9056a2937422aa6775f8c601c', '(21) 5477-8421', '2018-05-26 03:42:32', 1, '\\FotosPerfis\\usuarios\\216.561.235-55\\260520184352303.jpg', 'Lojinha do(a)antonio almeida', 0, 0, 0, 0, 0, '', '', '', 0, 2, 0, 2, 311),
	('217.832.455-52', 'cadastro rapdo', 'M', '1995-06-16', 'cadastro@rapido', 'c7d39eb8076cddec95735db4e0e094d3c4be197a0f885cbb514177b1017e056f87236d001b4c817df7ee17838d90910cb34134c9056a2937422aa6775f8c601c', '(12) 4545-7811', '2018-05-26 04:15:14', 1, '../../themes/images/FOTOPERFIL/este.gif', 'Lojinha do(a)cadastro rapdo', 0, 0, 0, 0, 0, '', '', '', 0, 2, 0, 2, 79),
	('218.924.567-22', 'ela moda', 'M', '1995-06-16', 'ela@moda', 'c7d39eb8076cddec95735db4e0e094d3c4be197a0f885cbb514177b1017e056f87236d001b4c817df7ee17838d90910cb34134c9056a2937422aa6775f8c601c', '(15) 4564-8445', '2018-06-17 19:02:16', 1, '\\FotosPerfis\\usuarios\\218.924.567-22\\170620180243257.png', 'Lojinha do(a)ela moda', 0, 0, 0, 0, 0, '', '', '', 0, 2, 0, 2, 25),
	('436.606.008-65', 'gabriel de paula ', 'M', '1995-06-16', 'gabriel_ps15@hotmail.com', 'c7d39eb8076cddec95735db4e0e094d3c4be197a0f885cbb514177b1017e056f87236d001b4c817df7ee17838d90910cb34134c9056a2937422aa6775f8c601c', '(12) 3016-6654', '2018-05-25 20:17:11', 1, '\\FotosPerfis\\usuarios\\436.606.008-65\\250520181808824.jpg', 'Lojinha do(a)gabriel de paula ', 0, 0, 0, 0, 0, '', '', '', 0, 2, 0, 1, 72),
	('445.687.874-51', 'nerd girl', 'M', '1995-06-16', 'nerd@girl', 'c7d39eb8076cddec95735db4e0e094d3c4be197a0f885cbb514177b1017e056f87236d001b4c817df7ee17838d90910cb34134c9056a2937422aa6775f8c601c', '(11) 2315-4644', '2018-05-25 21:14:53', 1, '\\FotosPerfis\\usuarios\\445.687.874-51\\250520181646365.jpg', 'Lojinha do(a)nerd girl', 0, 0, 0, 0, 0, '', '', '', 0, 2, 0, 2, 72),
	('457.897.465-13', 'Costa freire', 'M', '1987-12-18', 'costa@freire', 'c7d39eb8076cddec95735db4e0e094d3c4be197a0f885cbb514177b1017e056f87236d001b4c817df7ee17838d90910cb34134c9056a2937422aa6775f8c601c', '(48) 7946-1231', '2018-05-26 02:48:37', 1, '\\FotosPerfis\\usuarios\\457.897.465-13\\260520184953188.jpg', 'Lojinha do(a)Costa freire', 0, 0, 0, 0, 0, '', '', '', 0, 2, 0, 2, 72),
	('475.878.548-0', 'joao da silva', 'M', '1999-04-10', 'joao@hotamils.com', '1d73a38e9aebe1bac7eb9661ea6b378b4e374dc099588976a1e1f7a7eb205ab2f4b62c3647024cd2eadbac076ce4b3f2b7ac692739de4628509831b039a331ff', '(12) 3122-2145', '2018-06-11 20:36:50', 1, '../../themes/images/FOTOPERFIL/este.gif', 'Lojinha do(a)joao da silva', 0, 0, 0, 0, 0, '', '', '', 0, 2, 0, 2, 25),
	('756.475.445-11', 'marcelo vidas', 'M', '1984-06-16', 'marcelo@vidas', 'c7d39eb8076cddec95735db4e0e094d3c4be197a0f885cbb514177b1017e056f87236d001b4c817df7ee17838d90910cb34134c9056a2937422aa6775f8c601c', '(12) 5468-7844', '2018-05-25 20:48:16', 1, '\\FotosPerfis\\usuarios\\756.475.445-11\\250520184954971.jpg', 'Lojinha do(a)marcelo vidas', 0, 0, 0, 0, 0, '', '', '', 0, 2, 0, 2, 151);
/*!40000 ALTER TABLE `usu_usuarios` ENABLE KEYS */;

/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IF(@OLD_FOREIGN_KEY_CHECKS IS NULL, 1, @OLD_FOREIGN_KEY_CHECKS) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
