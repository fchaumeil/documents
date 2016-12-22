--
-- Creation de la table TYPE_CQP
--
drop table TYPE_CQP

CREATE TABLE TYPE_CQP (
  ID_TYPECQP int NOT NULL Identity(1, 1),
  COD_CQP varchar(45) NOT NULL ,
  LIB_CQP varchar(255) DEFAULT NULL,
  BLN_ACTIF tinyint not null,
  PRIMARY KEY (ID_TYPECQP)
) 

--
-- Contenu de la table TYPE_CQ`
--

INSERT INTO TYPE_CQP (COD_CQP, LIB_CQP, BLN_ACTIF) VALUES
('CH01', 'CQP Agent logistique des industries chimiques (H/F) Niveau V', 1),
('CH02', 'CQP Animateur(trice) d’équipe de conditionnement des industries chimiques Niveau III', 1),
('CH03', 'CQP Animateur(trice) d’équipe de fabrication des industries chimiques Niveau III', 1),
('CH04', 'CQP Animateur(trice) d’équipe de logistique des industries chimiques Niveau III', 1),
('CH05', 'CQP Animateur(trice) d’équipe de maintenance des industries chimiques Niveau III', 1),
('CH06', 'CQP Conducteur(trice) d’équipement de fabrication des industries chimiques Niveau IV', 1),
('CH07', 'CQP Conducteur(trice) de ligne de conditionnement des industries chimiques Niveau IV', 1),
('CH08', 'CQP Opérateur(trice) de fabrication des industries chimiques Niveau V', 1),
('CH09', 'CQP Opérateur(trice) de maintenance industrielle des industries chimiques Niveau V', 1),
( 'CH10', 'CQP Pilote d’installation de fabrication (H/F) des industries chimiques Niveau IV', 1),
( 'CH11', 'CQP Pilote de ligne de conditionnement (H/F) des industries chimiques Niveau IV', 1),
( 'CH12', 'CQP Technicien(ne) de maintenance Industrielle des industries chimiques Niveau IV', 1),
( 'CH13', 'CQPI Technicien de la Qualité', 1),
( 'CH14', 'CQPI Vente conseil en magasin', 1),
( 'PH01', 'CQP animation d''équipe option maintenance', 1),
( 'PH02', 'CQP animation d''équipe option logistique', 1),
( 'PH03', 'CQP animation d''équipe en production', 1),
( 'PH04', 'CQP conduite de ligne de conditionnement', 1),
( 'PH05', 'CQP conduite de procédé de fabrication', 1),
( 'PH06', 'CQP conduite de procédé de fabrication en bioproduction', 1),
( 'PH07', 'CQP conduite d''opérations logistiques', 1),
( 'PH08', 'CQP pilotage de procédé de conditionnement', 1),
( 'PH09', 'CQP pilotage de procédé de fabrication formes sèches', 1),
( 'PH10', 'CQP pilotage de procédé de fabrication formes liquides et pâteuses', 1),
( 'PH11', 'CQP maintenance des équipements de production de médicaments', 1),
( 'PH12', 'CQP vente et promotion de produits pharmaceutiques à l''officine', 1),
( 'PL01', 'CQP Assemblage Parachèvement Finitions', 1),
( 'PL02', 'CQP Chaudronnerie plastique', 1),
( 'PL03', 'CQP Conduite d''Equipement de Fabrication', 1),
( 'PL04', 'CQP Coordination de ligne ou d''ïlot', 1),
( 'PL05', 'CQP Encadrement d''équipe', 1),
( 'PL06', 'CQP Matériaux composites', 1),
( 'PL07', 'CQP Menuiseries extérieures', 1),
( 'PL08', 'CQP Montage réglage équipement fabrication', 1),
( 'PL09', 'CQP Techniques en production', 1),
( 'UN01', 'CQP animation d''équipe option maintenance', 1),
( 'UN02', 'CQP animation d''équipe option logistique', 1),
( 'UN03', 'CQP animation d''équipe en production', 1),
( 'UN04', 'CQP conduite de ligne de conditionnement', 1),
( 'UN05', 'CQP conduite de procédé de fabrication', 1),
( 'UN06', 'CQP conduite de procédé de fabrication en bioproduction', 1),
( 'UN07', 'CQP conduite d''opérations logistiques', 1),
( 'UN08', 'CQP pilotage de procédé de conditionnement', 1),
( 'UN09', 'CQP pilotage de procédé de fabrication formes sèches', 1),
( 'UN10', 'CQP pilotage de procédé de fabrication formes liquides et pâteuses', 1),
( 'UN11', 'CQP maintenance des équipements de production de médicaments', 1),
( 'UN12', 'CQP vente et promotion de produits pharmaceutiques à l''officine', 1);

