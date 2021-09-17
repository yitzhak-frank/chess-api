/* eslint-disable */

import { viewEvents } from "./view-events.js";
import { coronationHandler } from "./coronation.js";
import { popupMessageHandler } from "./popup.js";
import { insertTools, removeAllTools } from "./render.js";
import { fetchToolMoves, fetchMoveTool, fetchGameState } from "./http.js";

export const onToolClicked = pos => {
    const { state: { tools: { [getSelectedTool()]: tool1, [pos]: tool2 }, colorTurn }} = history;
    if (!getSelectedTool() && tool2.color !== colorTurn) return;
    if (!getSelectedTool() || tool1.color === tool2.color) getToolMoves(pos);
    else moveTool(pos);
}

const getToolMoves = async pos => {
    const moves = await fetchToolMoves(pos);
    if (moves.length) setSelectedTool(pos);
    unmarkMoves();
    markMoves(moves);
    popupMessageHandler();
}

export const moveTool = async pos => {
    await fetchMoveTool(getSelectedTool(), pos);
    rerenderTools();
    unmarkChess();
    unmarkMoves();
    getGameState();
    setSelectedTool(undefined);
    coronationHandler();
}

export const rerenderTools = () => {
    removeAllTools();
    insertTools();
    viewEvents();
}

export const getGameState = async () => {
    await fetchGameState();
    const { state: { isChess, colorThreatend: color } } = history;
    isChess && chess(color);
    popupMessageHandler();
}

const getKingPosition = color => {
    const { state: { tools } } = history;
    const kingPos = Object.values(tools).find(tool => tool.color === color && tool.rank === 'King').position;
    return kingPos;
}

const chess = color => markChess(getKingPosition(color));

const markMoves = moves => moves.forEach(move => $(`td .bg#${move}`).addClass('move'));

const unmarkMoves = () => $('td .bg').removeClass('move');

const markChess = pos => $(`td .bg#${pos}`).addClass('chess');

const unmarkChess = () => $(`td .bg`).removeClass('chess');

export const getSelectedTool = () => history.state.selectedTool;

export const setSelectedTool = pos => history.state.selectedTool = pos;
