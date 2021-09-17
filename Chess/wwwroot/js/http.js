/* eslint-disable */

const URL = '/api';

export const fetchGame = async () => {
    const url = URL + '/games/start-game';
    const { tools, gameId, colorTurn } = await fetch(url).then(async d => await d.json());
    history.pushState({ ...history.state, tools, gameId, colorTurn }, '');
}

export const fetchTable = async () => {
    const url = URL + '/games/get-table';
    const table = await fetch(url).then(async d => await d.json());
    history.pushState({ ...history.state, table }, '');
}

export const fetchToolMoves = async pos => {
    const { state: { gameId }, state } = history;
    const url = URL + `/game/get-moves/${gameId}?toolPos=${pos}`;
    const { moves, unallowedMoves } = await fetch(url).then(async d => await d.json());
    history.pushState({ ...state, messages: [...Object.values(unallowedMoves)]}, '');
    return moves;
}

export const fetchMoveTool = async (from, to) => {
    const { state: { gameId }, state } = history;
    const url = URL + `/game/move-tool/${gameId}?from=${from}&to=${to}`;
    const { tools, colorTurn, coronation } = await fetch(url).then(async d => await d.json());
    history.pushState({ ...state, tools, colorTurn, coronation }, '');
}

export const fetchGameState = async () => {
    const { state: { gameId }, state } = history;
    const url = URL + `/game/game-state/${gameId}`;
    const { isChess, isChessmate, colorThreatend, kingThreats, unallowedMoves } = await fetch(url).then(async d => await d.json());
    history.pushState({ ...state, isChess, isChessmate, colorThreatend, messages: [kingThreats, ...Object.values(unallowedMoves)]}, '');
}

export const fetchCoronate = async rank => {
    const { state: { gameId, coronation }, state } = history;
    const url = URL + `/game/coronate/${gameId}?toolPos=${coronation}&rank=${rank}`;
    const { tools } = await fetch(url).then(async d => await d.json());
    history.pushState({ ...state, tools, coronation: '' }, '');
}