// 
// THIS FILE HAS BEEN GENERATED AUTOMATICALLY
// DO NOT CHANGE IT MANUALLY UNLESS YOU KNOW WHAT YOU'RE DOING
// 
// GENERATED USING @colyseus/schema 0.5.41
// 

using Colyseus.Schema;

public class BoardState : Schema {
	[Type(0, "map", typeof(MapSchema<OPlayer>))]
	public MapSchema<OPlayer> players = new MapSchema<OPlayer>();

	[Type(1, "string")]
	public string phase = "";

	[Type(2, "int16")]
	public short playerTurn = 0;

	[Type(3, "int16")]
	public short winningPlayer = 0;

	[Type(4, "int16")]
	public short lastDiceValue = 0;
}

