// 
// THIS FILE HAS BEEN GENERATED AUTOMATICALLY
// DO NOT CHANGE IT MANUALLY UNLESS YOU KNOW WHAT YOU'RE DOING
// 
// GENERATED USING @colyseus/schema 0.5.41
// 

using Colyseus.Schema;

public class OPlayer : Schema {
	[Type(0, "map", typeof(MapSchema<OPiece>))]
	public MapSchema<OPiece> pieces = new MapSchema<OPiece>();

	[Type(1, "boolean")]
	public bool connected = false;

	[Type(2, "int16")]
	public short seat = 0;

	[Type(3, "int16")]
	public short startOffset = 0;

	[Type(4, "string")]
	public string sessionId = "";

	[Type(5, "string")]
	public string phase = "";

	[Type(6, "boolean")]
	public bool isVir = false;

	[Type(7, "boolean")]
	public bool isBot = false;

	[Type(8, "int16")]
	public short lostTurn = 0;

	[Type(9, "string")]
	public string selectedPieceRing = "";

	[Type(10, "string")]
	public string selectedPieceIcon = "";

	[Type(11, "string")]
	public string selectedPieceGem = "";

	[Type(12, "string")]
	public string nickName = "";

	[Type(13, "int16")]
	public short entrance = 0;
}

