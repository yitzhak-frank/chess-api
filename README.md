# Chess Api README

## Routes

**Games Route**

**Get table**:  
_Method_ - GET  
_Route_ - `/api/games/get-table`
_Response_
{
&emsp;[
&emsp;&emsp;["A1", "A2", "A3", "A4", "A5", "A6", "A7", "A8"],
&emsp;&emsp;["B1", "B2", "B3", "B4", "B5", "B6", "B7", "B8"],
&emsp;&emsp;["C1", "C2", "C3", "C4", "C5", "C6", "C7", "C8"],
&emsp;&emsp;["D1", "D2", "D3", "D4", "D5", "D6", "D7", "D8"],
&emsp;&emsp;["E1", "E2", "E3", "E4", "E5", "E6", "E7", "E8"],
&emsp;&emsp;["F1", "F2", "F3", "F4", "F5", "F6", "F7", "F8"],
&emsp;&emsp;["G1", "G2", "G3", "G4", "G5", "G6", "G7", "G8"],
&emsp;&emsp;["H1", "H2", "H3", "H4", "H5", "H6", "H7", "H8"]
&emsp;]
}

**Get tools**:  
_Method_ - GET  
_Route_ - `/api/games/get-tools`
_Response_
{
&emsp;{
&emsp;&emsp;"A1": {
&emsp;&emsp;&emsp;"color": boolean,
&emsp;&emsp;&emsp;"tool": string,
&emsp;&emsp;&emsp;"position": string,
&emsp;&emsp;&emsp;"isVirgin": boolean,
&emsp;&emsp;&emsp;"rank": string
&emsp;&emsp;},
&emsp;&emsp;"B1": {
&emsp;&emsp;&emsp;"color": boolean,
&emsp;&emsp;&emsp;"tool": string,
&emsp;&emsp;&emsp;"position": string,
&emsp;&emsp;&emsp;"isVirgin": boolean,
&emsp;&emsp;&emsp;"rank": string
&emsp;&emsp;},
&emsp;&emsp;"C1": {
&emsp;&emsp;&emsp;"color": boolean,
&emsp;&emsp;&emsp;"tool": string,
&emsp;&emsp;&emsp;"position": string,
&emsp;&emsp;&emsp;"isVirgin": boolean,
&emsp;&emsp;&emsp;"rank": string
&emsp;&emsp;}
&emsp;&emsp;...
&emsp;}
}

**Start game**:  
_Method_ - GET  
_Route_ - `/api/games/start-game`
_Response_
{
&emsp;{
&emsp;&emsp;"message": string,
&emsp;&emsp;"gammeId" : long,
&emsp;&emsp;"tools" : {
&emsp;&emsp;&emsp;"A1": {
&emsp;&emsp;&emsp;&emsp;"color": boolean,
&emsp;&emsp;&emsp;&emsp;"tool": string,
&emsp;&emsp;&emsp;&emsp;"position": string,
&emsp;&emsp;&emsp;&emsp;"isVirgin": boolean,
&emsp;&emsp;&emsp;&emsp;"rank": string
&emsp;&emsp;&emsp;},
&emsp;&emsp;&emsp;"B1": {
&emsp;&emsp;&emsp;&emsp;"color": boolean,
&emsp;&emsp;&emsp;&emsp;"tool": string,
&emsp;&emsp;&emsp;&emsp;"position": string,
&emsp;&emsp;&emsp;&emsp;"isVirgin": boolean,
&emsp;&emsp;&emsp;&emsp;"rank": string
&emsp;&emsp;&emsp;},
&emsp;&emsp;&emsp;"C1": {
&emsp;&emsp;&emsp;&emsp;"color": boolean,
&emsp;&emsp;&emsp;&emsp;"tool": string,
&emsp;&emsp;&emsp;&emsp;"position": string,
&emsp;&emsp;&emsp;&emsp;"isVirgin": boolean,
&emsp;&emsp;&emsp;&emsp;"rank": string
&emsp;&emsp;&emsp;}
&emsp;&emsp;&emsp;...
&emsp;&emsp;}
&emsp;}
}

**Restart game**:  
_Method_ - POST  
_Route_ - `/api/games/restart-game`
_Body_
{
&emsp;{
&emsp;&emsp;"A1": {
&emsp;&emsp;&emsp;"color": boolean,
&emsp;&emsp;&emsp;"tool": string,
&emsp;&emsp;&emsp;"position": string,
&emsp;&emsp;&emsp;"isVirgin": boolean,
&emsp;&emsp;&emsp;"rank": string
&emsp;&emsp;},
&emsp;&emsp;"B1": {
&emsp;&emsp;&emsp;"color": boolean,
&emsp;&emsp;&emsp;"tool": string,
&emsp;&emsp;&emsp;"position": string,
&emsp;&emsp;&emsp;"isVirgin": boolean,
&emsp;&emsp;&emsp;"rank": string
&emsp;&emsp;},
&emsp;&emsp;"C1": {
&emsp;&emsp;&emsp;"color": boolean,
&emsp;&emsp;&emsp;"tool": string,
&emsp;&emsp;&emsp;"position": string,
&emsp;&emsp;&emsp;"isVirgin": boolean,
&emsp;&emsp;&emsp;"rank": string
&emsp;&emsp;}
&emsp;&emsp;...
&emsp;}
}
_Response_
{
&emsp;{
&emsp;&emsp;"message": string,
&emsp;&emsp;"gammeId" : long,
&emsp;&emsp;"tools" : {
&emsp;&emsp;&emsp;"A1": {
&emsp;&emsp;&emsp;&emsp;"color": boolean,
&emsp;&emsp;&emsp;&emsp;"tool": string,
&emsp;&emsp;&emsp;&emsp;"position": string,
&emsp;&emsp;&emsp;&emsp;"isVirgin": boolean,
&emsp;&emsp;&emsp;&emsp;"rank": string
&emsp;&emsp;&emsp;},
&emsp;&emsp;&emsp;"B1": {
&emsp;&emsp;&emsp;&emsp;"color": boolean,
&emsp;&emsp;&emsp;&emsp;"tool": string,
&emsp;&emsp;&emsp;&emsp;"position": string,
&emsp;&emsp;&emsp;&emsp;"isVirgin": boolean,
&emsp;&emsp;&emsp;&emsp;"rank": string
&emsp;&emsp;&emsp;},
&emsp;&emsp;&emsp;"C1": {
&emsp;&emsp;&emsp;&emsp;"color": boolean,
&emsp;&emsp;&emsp;&emsp;"tool": string,
&emsp;&emsp;&emsp;&emsp;"position": string,
&emsp;&emsp;&emsp;&emsp;"isVirgin": boolean,
&emsp;&emsp;&emsp;&emsp;"rank": string
&emsp;&emsp;&emsp;}
&emsp;&emsp;&emsp;...
&emsp;&emsp;}
&emsp;}
}

---

**Game Route**

**Get all posts**:  
_Method_: GET  
_Route_: `/api/game/get-game-tools/{gameId}`
_Parameters_
{
&emsp; (path) `gameId`: long  
}
_Response_
{
&emsp;{
&emsp;&emsp;"A1": {
&emsp;&emsp;&emsp;"color": boolean,
&emsp;&emsp;&emsp;"tool": string,
&emsp;&emsp;&emsp;"position": string,
&emsp;&emsp;&emsp;"isVirgin": boolean,
&emsp;&emsp;&emsp;"rank": string
&emsp;&emsp;},
&emsp;&emsp;"B1": {
&emsp;&emsp;&emsp;"color": boolean,
&emsp;&emsp;&emsp;"tool": string,
&emsp;&emsp;&emsp;"position": string,
&emsp;&emsp;&emsp;"isVirgin": boolean,
&emsp;&emsp;&emsp;"rank": string
&emsp;&emsp;},
&emsp;&emsp;"C1": {
&emsp;&emsp;&emsp;"color": boolean,
&emsp;&emsp;&emsp;"tool": string,
&emsp;&emsp;&emsp;"position": string,
&emsp;&emsp;&emsp;"isVirgin": boolean,
&emsp;&emsp;&emsp;"rank": string
&emsp;&emsp;}
&emsp;&emsp;...
&emsp;}
}

**Get tool moves**  
_Method_ - GET  
_Route_ - `/api/game/get-moves/{gameId}`
_Parameters_
{
&emsp; (path) `gameId`: long  
&emsp; (query) `toolPos`: string  
}
_Response_
{
&emsp;{
&emsp;&emsp;"message": string,
&emsp;&emsp;"moves": [
&emsp;&emsp;&emsp;string
&emsp;&emsp;],
&emsp;&emsp;"unallowedMoves": {
&emsp;&emsp;&emsp;"A1": string,
&emsp;&emsp;&emsp;"B1": string,
&emsp;&emsp;&emsp;"C1": string
&emsp;&emsp;&emsp;...
&emsp;&emsp;}
&emsp;}
}

**Move tool**:  
_Method_ - GET  
_Route_ - `/api/game/move-tool/{gameId}`  
_Parameters_ - {  
&emsp; (path) `gameId`: long  
&emsp; (query) `from`: string
&emsp; (query) `to`: string
_Response_
{
&emsp;{
&emsp;&emsp;"success": boolean
&emsp;&emsp;"message": string,
&emsp;&emsp;"tools" : {
&emsp;&emsp;&emsp;"A1": {
&emsp;&emsp;&emsp;&emsp;"color": boolean,
&emsp;&emsp;&emsp;&emsp;"tool": string,
&emsp;&emsp;&emsp;&emsp;"position": string,
&emsp;&emsp;&emsp;&emsp;"isVirgin": boolean,
&emsp;&emsp;&emsp;&emsp;"rank": string
&emsp;&emsp;&emsp;},
&emsp;&emsp;&emsp;"B1": {
&emsp;&emsp;&emsp;&emsp;"color": boolean,
&emsp;&emsp;&emsp;&emsp;"tool": string,
&emsp;&emsp;&emsp;&emsp;"position": string,
&emsp;&emsp;&emsp;&emsp;"isVirgin": boolean,
&emsp;&emsp;&emsp;&emsp;"rank": string
&emsp;&emsp;&emsp;},
&emsp;&emsp;&emsp;"C1": {
&emsp;&emsp;&emsp;&emsp;"color": boolean,
&emsp;&emsp;&emsp;&emsp;"tool": string,
&emsp;&emsp;&emsp;&emsp;"position": string,
&emsp;&emsp;&emsp;&emsp;"isVirgin": boolean,
&emsp;&emsp;&emsp;&emsp;"rank": string
&emsp;&emsp;&emsp;}
&emsp;&emsp;&emsp;...
&emsp;&emsp;}
&emsp;}
}

**Game state**:  
_Method_ - GET  
_Route_ - `/api/game/game-state/{gameId}`  
_Parameters_
{
&emsp; (path) `gameId`: long  
&emsp; (query) `colorTurn`: boolean (can be as string)  
}
_Response_
{
&emsp;{
&emsp;&emsp;"gameState": string,
&emsp;&emsp;"kingThreats": string,
&emsp;&emsp;"unallowedMoves": {
&emsp;&emsp;&emsp;"A1": string,
&emsp;&emsp;&emsp;"B1": string,
&emsp;&emsp;&emsp;"C1": string
&emsp;&emsp;&emsp;...
&emsp;&emsp;}
&emsp;}
}
