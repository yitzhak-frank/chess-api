# Chess Api README

## Routes

**Games Route**

**Get table**:  
_Method_ - GET  
_Route_ - `/api/games/get-table`<br />

<details>
<summary>Response</summary><br />
{<br />
&emsp;[<br />
&emsp;&emsp;["A1", "A2", "A3", "A4", "A5", "A6", "A7", "A8"],<br />
&emsp;&emsp;["B1", "B2", "B3", "B4", "B5", "B6", "B7", "B8"],<br />
&emsp;&emsp;["C1", "C2", "C3", "C4", "C5", "C6", "C7", "C8"],<br />
&emsp;&emsp;["D1", "D2", "D3", "D4", "D5", "D6", "D7", "D8"],<br />
&emsp;&emsp;["E1", "E2", "E3", "E4", "E5", "E6", "E7", "E8"],<br />
&emsp;&emsp;["F1", "F2", "F3", "F4", "F5", "F6", "F7", "F8"],<br />
&emsp;&emsp;["G1", "G2", "G3", "G4", "G5", "G6", "G7", "G8"],<br />
&emsp;&emsp;["H1", "H2", "H3", "H4", "H5", "H6", "H7", "H8"]<br />
&emsp;]<br />
}
</details>

**Get tools**:  
_Method_ - GET  
_Route_ - `/api/games/get-tools`<br />

<details>
<summary>Response</summary><br />
{<br />
&emsp;{<br />
&emsp;&emsp;"A1": {<br />
&emsp;&emsp;&emsp;"color": boolean,<br />
&emsp;&emsp;&emsp;"tool": string,<br />
&emsp;&emsp;&emsp;"position": string,<br />
&emsp;&emsp;&emsp;"isVirgin": boolean,<br />
&emsp;&emsp;&emsp;"rank": string<br />
&emsp;&emsp;},<br />
&emsp;&emsp;"B1": {<br />
&emsp;&emsp;&emsp;"color": boolean,<br />
&emsp;&emsp;&emsp;"tool": string,<br />
&emsp;&emsp;&emsp;"position": string,<br />
&emsp;&emsp;&emsp;"isVirgin": boolean,<br />
&emsp;&emsp;&emsp;"rank": string<br />
&emsp;&emsp;},<br />
&emsp;&emsp;"C1": {<br />
&emsp;&emsp;&emsp;"color": boolean,<br />
&emsp;&emsp;&emsp;"tool": string,<br />
&emsp;&emsp;&emsp;"position": string,<br />
&emsp;&emsp;&emsp;"isVirgin": boolean,<br />
&emsp;&emsp;&emsp;"rank": string<br />
&emsp;&emsp;}<br />
&emsp;&emsp;<strong>...</strong><br />
&emsp;}<br />
}
</details>

**Start game**:  
_Method_ - GET  
_Route_ - `/api/games/start-game`<br />

<details>
<summary>Response</summary><br />
{<br />
&emsp;{<br />
&emsp;&emsp;"message": string,<br />
&emsp;&emsp;"gammeId" : long,<br />
&emsp;&emsp;"tools" : {<br />
&emsp;&emsp;&emsp;"A1": {<br />
&emsp;&emsp;&emsp;&emsp;"color": boolean,<br />
&emsp;&emsp;&emsp;&emsp;"tool": string,<br />
&emsp;&emsp;&emsp;&emsp;"position": string,<br />
&emsp;&emsp;&emsp;&emsp;"isVirgin": boolean,<br />
&emsp;&emsp;&emsp;&emsp;"rank": string<br />
&emsp;&emsp;&emsp;},<br />
&emsp;&emsp;&emsp;"B1": {<br />
&emsp;&emsp;&emsp;&emsp;"color": boolean,<br />
&emsp;&emsp;&emsp;&emsp;"tool": string,<br />
&emsp;&emsp;&emsp;&emsp;"position": string,<br />
&emsp;&emsp;&emsp;&emsp;"isVirgin": boolean,<br />
&emsp;&emsp;&emsp;&emsp;"rank": string<br />
&emsp;&emsp;&emsp;},<br />
&emsp;&emsp;&emsp;"C1": {<br />
&emsp;&emsp;&emsp;&emsp;"color": boolean,<br />
&emsp;&emsp;&emsp;&emsp;"tool": string,<br />
&emsp;&emsp;&emsp;&emsp;"position": string,<br />
&emsp;&emsp;&emsp;&emsp;"isVirgin": boolean,<br />
&emsp;&emsp;&emsp;&emsp;"rank": string<br />
&emsp;&emsp;&emsp;}<br />
&emsp;&emsp;&emsp;<strong>...</strong><br />
&emsp;&emsp;}<br />
&emsp;}<br />
}
</details>

**Restart game**:  
_Method_ - POST  
_Route_ - `/api/games/restart-game`<br />
_Body_<br />
{<br />
&emsp;{<br />
&emsp;&emsp;"A1": {<br />
&emsp;&emsp;&emsp;"color": boolean,<br />
&emsp;&emsp;&emsp;"tool": string,<br />
&emsp;&emsp;&emsp;"position": string,<br />
&emsp;&emsp;&emsp;"isVirgin": boolean,<br />
&emsp;&emsp;&emsp;"rank": string<br />
&emsp;&emsp;},<br />
&emsp;&emsp;"B1": {<br />
&emsp;&emsp;&emsp;"color": boolean,<br />
&emsp;&emsp;&emsp;"tool": string,<br />
&emsp;&emsp;&emsp;"position": string,<br />
&emsp;&emsp;&emsp;"isVirgin": boolean,<br />
&emsp;&emsp;&emsp;"rank": string<br />
&emsp;&emsp;},<br />
&emsp;&emsp;"C1": {<br />
&emsp;&emsp;&emsp;"color": boolean,<br />
&emsp;&emsp;&emsp;"tool": string,<br />
&emsp;&emsp;&emsp;"position": string,<br />
&emsp;&emsp;&emsp;"isVirgin": boolean,<br />
&emsp;&emsp;&emsp;"rank": string<br />
&emsp;&emsp;}<br />
&emsp;&emsp;<strong>...</strong><br />
&emsp;}<br />
}<br />

<details>
<summary>Response</summary><br />
{<br />
&emsp;{<br />
&emsp;&emsp;"message": string,<br />
&emsp;&emsp;"gammeId" : long,<br />
&emsp;&emsp;"tools" : {<br />
&emsp;&emsp;&emsp;"A1": {<br />
&emsp;&emsp;&emsp;&emsp;"color": boolean,<br />
&emsp;&emsp;&emsp;&emsp;"tool": string,<br />
&emsp;&emsp;&emsp;&emsp;"position": string,<br />
&emsp;&emsp;&emsp;&emsp;"isVirgin": boolean,<br />
&emsp;&emsp;&emsp;&emsp;"rank": string<br />
&emsp;&emsp;&emsp;},<br />
&emsp;&emsp;&emsp;"B1": {<br />
&emsp;&emsp;&emsp;&emsp;"color": boolean,<br />
&emsp;&emsp;&emsp;&emsp;"tool": string,<br />
&emsp;&emsp;&emsp;&emsp;"position": string,<br />
&emsp;&emsp;&emsp;&emsp;"isVirgin": boolean,<br />
&emsp;&emsp;&emsp;&emsp;"rank": string<br />
&emsp;&emsp;&emsp;},<br />
&emsp;&emsp;&emsp;"C1": {<br />
&emsp;&emsp;&emsp;&emsp;"color": boolean,<br />
&emsp;&emsp;&emsp;&emsp;"tool": string,<br />
&emsp;&emsp;&emsp;&emsp;"position": string,<br />
&emsp;&emsp;&emsp;&emsp;"isVirgin": boolean,<br />
&emsp;&emsp;&emsp;&emsp;"rank": string<br />
&emsp;&emsp;&emsp;}<br />
&emsp;&emsp;&emsp;<strong>...</strong><br />
&emsp;&emsp;}<br />
&emsp;}<br />
}
</details>

---

**Game Route**

**Get game tools**:  
_Method_: GET  
_Route_: `/api/game/get-game-tools/{gameId}`<br />
_Parameters_<br />
{<br />
&emsp; (path) `gameId`: long <br />
}<br />

<details>
<summary>Response</summary><br />
{<br />
&emsp;{<br />
&emsp;&emsp;"A1": {<br />
&emsp;&emsp;&emsp;"color": boolean,<br />
&emsp;&emsp;&emsp;"tool": string,<br />
&emsp;&emsp;&emsp;"position": string,<br />
&emsp;&emsp;&emsp;"isVirgin": boolean,<br />
&emsp;&emsp;&emsp;"rank": string<br />
&emsp;&emsp;},<br />
&emsp;&emsp;"B1": {<br />
&emsp;&emsp;&emsp;"color": boolean,<br />
&emsp;&emsp;&emsp;"tool": string,<br />
&emsp;&emsp;&emsp;"position": string,<br />
&emsp;&emsp;&emsp;"isVirgin": boolean,<br />
&emsp;&emsp;&emsp;"rank": string<br />
&emsp;&emsp;},<br />
&emsp;&emsp;"C1": {<br />
&emsp;&emsp;&emsp;"color": boolean,<br />
&emsp;&emsp;&emsp;"tool": string,<br />
&emsp;&emsp;&emsp;"position": string,<br />
&emsp;&emsp;&emsp;"isVirgin": boolean,<br />
&emsp;&emsp;&emsp;"rank": string<br />
&emsp;&emsp;}<br />
&emsp;&emsp;<strong>...</strong><br />
&emsp;}<br />
}
</details>

**Get tool moves**  
_Method_ - GET  
_Route_ - `/api/game/get-moves/{gameId}`<br />
_Parameters_<br />
{<br />
&emsp; (path) `gameId`: long <br />
&emsp; (query) `toolPos`: string <br />
}<br />

<details>
<summary>Response</summary><br />
{<br />
&emsp;{<br />
&emsp;&emsp;"message": string,<br />
&emsp;&emsp;"moves": [<br />
&emsp;&emsp;&emsp;string<br />
&emsp;&emsp;],<br />
&emsp;&emsp;"unallowedMoves": {<br />
&emsp;&emsp;&emsp;"A1": string,<br />
&emsp;&emsp;&emsp;"B1": string,<br />
&emsp;&emsp;&emsp;"C1": string<br />
&emsp;&emsp;&emsp;<strong>...</strong><br />
&emsp;&emsp;}<br />
&emsp;}<br />
}
</details>

**Move tool**:  
_Method_ - GET  
_Route_ - `/api/game/move-tool/{gameId}`<br />
_Parameters_ <br />
{<br />
&emsp; (path) `gameId`: long <br />
&emsp; (query) `from`: string<br />
&emsp; (query) `to`: string<br />
}<br />

<details>
<summary>Response</summary><br />
{<br />
&emsp;{<br />
&emsp;&emsp;"success": boolean<br />
&emsp;&emsp;"message": string,<br />
&emsp;&emsp;"tools" : {<br />
&emsp;&emsp;&emsp;"A1": {<br />
&emsp;&emsp;&emsp;&emsp;"color": boolean,<br />
&emsp;&emsp;&emsp;&emsp;"tool": string,<br />
&emsp;&emsp;&emsp;&emsp;"position": string,<br />
&emsp;&emsp;&emsp;&emsp;"isVirgin": boolean,<br />
&emsp;&emsp;&emsp;&emsp;"rank": string<br />
&emsp;&emsp;&emsp;},<br />
&emsp;&emsp;&emsp;"B1": {<br />
&emsp;&emsp;&emsp;&emsp;"color": boolean,<br />
&emsp;&emsp;&emsp;&emsp;"tool": string,<br />
&emsp;&emsp;&emsp;&emsp;"position": string,<br />
&emsp;&emsp;&emsp;&emsp;"isVirgin": boolean,<br />
&emsp;&emsp;&emsp;&emsp;"rank": string<br />
&emsp;&emsp;&emsp;},<br />
&emsp;&emsp;&emsp;"C1": {<br />
&emsp;&emsp;&emsp;&emsp;"color": boolean,<br />
&emsp;&emsp;&emsp;&emsp;"tool": string,<br />
&emsp;&emsp;&emsp;&emsp;"position": string,<br />
&emsp;&emsp;&emsp;&emsp;"isVirgin": boolean,<br />
&emsp;&emsp;&emsp;&emsp;"rank": string<br />
&emsp;&emsp;&emsp;}<br />
&emsp;&emsp;&emsp;<strong>...</strong><br />
&emsp;&emsp;}<br />
&emsp;}<br />
}
</details>

**Game state**:  
_Method_ - GET  
_Route_ - `/api/game/game-state/{gameId}`<br />
_Parameters_<br />
{<br />
&emsp; (path) `gameId`: long <br />
&emsp; (query) `colorTurn`: boolean (can be as string) <br />
}<br />

<details>
<summary>Response</summary><br />
{<br />
&emsp;{<br />
&emsp;&emsp;"gameState": string,<br />
&emsp;&emsp;"kingThreats": string,<br />
&emsp;&emsp;"unallowedMoves": {<br />
&emsp;&emsp;&emsp;"A1": string,<br />
&emsp;&emsp;&emsp;"B1": string,<br />
&emsp;&emsp;&emsp;"C1": string<br />
&emsp;&emsp;&emsp;<strong>...</strong><br />
&emsp;&emsp;}<br />
&emsp;}<br />
}<br />
</details>
