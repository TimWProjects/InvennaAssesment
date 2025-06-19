export interface GeographicalDataItem {
  id: number;
  openbareRuimte: string;
  huisnummer: number;
  huisLetter?: string;
  huisNummerToevoeging?: number;
  postcode: string;
  woonplaats: string;
  gemeente: string;
  provincie: string;
  nummerAanduiding: string;
  verblijfsobjectGebruiksdoel: string;
  oppervlakteVerblijfsobject: number;
  verblijfsobjectStatus: string;
  object_Id: string;
  object_Type: string;
  nevenAdres: string;
  pandId: string;
  pandStatus: string;
  pandBouwjaar: number;
  x: number;
  y: number;
  lon: number;
  lat: number;
}
