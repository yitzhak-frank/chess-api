/* eslint-disable */

import { PopupTimer } from "./popup.js";
import { viewEvents } from "./view-events.js";
import { getGameState } from "./game-manager.js";
import { coronationHandler } from "./coronation.js";
import { fetchGame, fetchTable } from "./http.js";
import { renderHTML, insertTools } from "./render.js";

$(() => init());

const init = async () => {
    await initData();
    renderHTML();
    insertTools();
    viewEvents();
    getGameState();
    coronationHandler();
    history.state.Timer = new PopupTimer(0, () => {});
}

const initData = async () => {
    const { tools, gameId, table } = history.state || {};
    if (!table) await fetchTable();
    if (!tools || !gameId) await fetchGame();
}
