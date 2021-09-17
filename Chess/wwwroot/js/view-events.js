/* eslint-disable */

import { coronate } from "./coronation.js";
import { closePopup } from "./popup.js";
import { dragAndDrop } from "./drag-drop.js";
import { getSelectedTool, moveTool, onToolClicked } from "./game-manager.js";

export const viewEvents = () => {

    $('.tool')
        .off('mousedown').on('mousedown', e => dragAndDrop(e, e.target))
        .off('pointerdown').on('pointerdown', ({ target: { parentNode: { id }}}) => onToolClicked(id))
        .off('drop').on('drop', ({ target: { parentNode: { id }}}) => onToolClicked(id));

    $('td .bg').off('click').on('click', ({ target: { id, className }}) => 
        !className.includes('tool') && getSelectedTool() && moveTool(id));

    $('.toast')
        .off('mouseleave').on('mouseleave', () => history.state.Timer.resume())
        .off('mouseenter').on('mouseenter', () => history.state.Timer.pause());

    $('.toast .close-popup').off('click').on('click', closePopup);

    $('.coronation .option').off('click').on('click', ({ target: { id }}) => coronate(id));
}
