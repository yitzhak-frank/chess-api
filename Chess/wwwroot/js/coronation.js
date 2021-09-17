/* eslint-disable */

import { viewEvents } from "./view-events.js";
import { fetchCoronate } from "./http.js";
import { getGameState, rerenderTools } from "./game-manager.js";

const coronationOptions = [
    { black: '♛', white: '♕', rank: 'Queen' },
    { black: '♜', white: '♖', rank: 'Rook' },
    { black: '♝', white: '♗', rank: 'Bishop' },
    { black: '♞', white: '♘', rank: 'Knight' }
]

export const coronationHandler = () => {
    const { state: { coronation, tools: { [coronation]: tool }}} = history;
    if(!coronation || !tool) return;
    
    showCoronationPopup(tool);
    viewEvents();
}

const showCoronationPopup = tool => {
    $('.coronation-container').css('display', 'flex');
    $('.coronation').empty();
    coronationOptions.forEach(option => $('.coronation').append(`<div class="option" id="${option.rank}">${option[tool.color ? 'white' : 'black']}</div>`));
}

const hideCoronationPopup = () => $('.coronation-container').hide();

export const coronate = async rank => {
    await fetchCoronate(rank);
    rerenderTools();
    hideCoronationPopup();
    getGameState();
}