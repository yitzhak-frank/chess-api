/* eslint-disable */

$(() => init());

const URL = '/api';
let selectedTool;
let Timer = null;

const init = async () => {
    await initData();
    renderHTML();
    insertTools();
    viewEvents();
    getGameState();
}

const initData = async () => {
    const { tools, gameId, table } = history.state || {};
    if (!table) await fetchTable();
    if (!tools || !gameId) await fetchGame();
}

const fetchGame = async () => {
    const url = URL + '/games/start-game';
    const { tools, gameId, colorTurn } = await fetch(url).then(async d => await d.json());
    history.pushState({ ...history.state, tools, gameId, colorTurn }, '');
}

const fetchTable = async () => {
    const url = URL + '/games/get-table';
    const table = await fetch(url).then(async d => await d.json());
    history.pushState({ ...history.state, table }, '');
}

const fetchToolMoves = async pos => {
    const { state: { gameId }, state } = history;
    const url = URL + `/game/get-moves/${gameId}?toolPos=${pos}`;
    const { moves, unallowedMoves } = await fetch(url).then(async d => await d.json());
    history.pushState({ ...state, messages: [...Object.values(unallowedMoves)]}, '');
    return moves;
}

const fetchMoveTool = async (from, to) => {
    const { state: { gameId }, state } = history;
    const url = URL + `/game/move-tool/${gameId}?from=${from}&to=${to}`;
    const { tools, colorTurn } = await fetch(url).then(async d => await d.json());
    history.pushState({ ...state, tools, colorTurn }, '');
}

const fetchGameState = async () => {
    const { state: { gameId }, state } = history;
    const url = URL + `/game/game-state/${gameId}`;
    const { isChess, isChessmate, colorThreatend, kingThreats, unallowedMoves } = await fetch(url).then(async d => await d.json());
    history.pushState({ ...state, isChess, isChessmate, colorThreatend, messages: [kingThreats, ...Object.values(unallowedMoves)]}, '');
}

const renderHTML = () => {
    const { state: { table: matrix } } = history;
    const table = $('.table-container table');
    
    matrix.forEach((row, x) => {
        const tr = $(`<tr class="row"></tr>`);
        table.append(tr);

        row.forEach((col, y) => {
            const td = $(`<td class="col"><div id="${matrix[y][x]}" class="bg"></div></td>`);
            tr.append(td);
        })
    });
}

const insertTools = () => {
    const { state: { table, tools } } = history;
    table.forEach((row) => row.forEach((col) => tools[col] && $(`td .bg#${col}`).html(`<div class="tool">${tools[col].tool}</div>`)));
}

const viewEvents = () => {
    $('.tool').off('mousedown').on('mousedown', e => dragAndDrop(e, e.target))
        .off('pointerdown').on('pointerdown', ({ target: { parentNode: { id }}}) => onToolClicked(id))
        .off('drop').on('drop', ({ target: { parentNode: { id }}}) => onToolClicked(id));
    $('td .bg').off('click').on('click', ({ target: { id, className }}) => !className.includes('tool') && onEmptyCellClicked(id));
    $('.toast').off('mouseleave').on('mouseleave', () => Timer.resume()).off('mouseenter').on('mouseenter', () => Timer.pause());
    $('.toast .close-popup').off('click').on('click', closePopup);
}

const onToolClicked = pos => {
    const { state: { tools: { [selectedTool]: tool1, [pos]: tool2 }, colorTurn }} = history;
    if (!selectedTool && tool2.color !== colorTurn) return;
    if (!selectedTool || tool1.color === tool2.color) getToolMoves(pos);
    else moveTool(pos);
}

const onEmptyCellClicked = pos => selectedTool && moveTool(pos);

const getToolMoves = async pos => {
    const moves = await fetchToolMoves(pos);
    if (moves.length) selectedTool = pos;
    unmarkMoves();
    markMoves(moves);
    popupMessageHandler();
}

const moveTool = async pos => {
    await fetchMoveTool(selectedTool, pos);
    removeAllTools();
    insertTools();
    viewEvents();
    unmarkChess();
    unmarkMoves();
    getGameState();
    selectedTool = undefined;
}

const getGameState = async () => {
    await fetchGameState();
    const { state: { isChess, colorThreatend: color } } = history;
    isChess && chess(color);
    popupMessageHandler();
}

const chess = color => {
    markChess(getKingPosition(color));
}

const getKingPosition = color => {
    const { state: { tools } } = history;
    const kingPos = Object.values(tools).find(tool => tool.color === color && tool.rank === 'King').position;
    return kingPos;
}

const removeAllTools = () => $('.tool').remove();

const markMoves = moves => moves.forEach(move => $(`td .bg#${move}`).addClass('move'));

const unmarkMoves = () => $('td .bg').removeClass('move');

const markChess = pos => $(`td .bg#${pos}`).addClass('chess');

const unmarkChess = () => $(`td .bg`).removeClass('chess');

const closePopup = () => $('.toast').fadeOut(500).children('.toast .progress-bar').css({'transition': 'none', 'width': '0'});

const popupMessageHandler = () => {
    
    Timer && clearTimeout(Timer.timeoutId);
    closePopup();

    const { state: { messages }} = history;
    if(!messages.length || messages.every(msg => !msg)) return;
    
    $('.toast .message').html('<ul></ul>');
    messages.forEach(msg => $('.toast .message ul').append(`<li>${msg}</li>`));
    $('.toast').fadeIn(500);

    Timer = new PopupTimer(5000, closePopup);
    Timer.resume();
}

const dragAndDrop = (event, element) => {

    const startDragElement = e => {
        e.preventDefault();
        document.onmouseup = stopDragElement;
        document.onmousemove = dragElement;
    }

    const dragElement = e => {
        e.preventDefault();
        $(element).css({
            'position': 'fixed', 
            'top': (e.y - (element.clientHeight/2)) + "px", 
            'left': (e.x - (element.clientWidth/2))  + "px", 
            transform: 'scale(1.2)'
        });
    }

    const stopDragElement = e => {
        $(element).css({'position': '', 'top': '', 'left': '', 'visibility': 'hidden'}).delay(10).queue(() => $(element).css('visibility', 'visible'));;
        document.onmouseup = null;
        document.onmousemove = null;
        dropElement(e);
    }

    const dropElement = ({ x, y }) => {
      const target = document.elementFromPoint(x, y);
      if(element === target) return;
      const click  = function() { this.click() };
      $(target).on('drop', click).trigger('drop').off('drop', click);
    }

    startDragElement(event);
}

class PopupTimer {
    
    #time;
    #callback;
    timeoutId;
    #start = Date.now();
    #bar = $('.toast .progress-bar');

    constructor(time, callback) {
        this.#time = time;
        this.#callback = callback;
    }

    pause() {
        clearTimeout(this.timeoutId);
        this.#time -= (Date.now() - this.#start);
        this.#bar.css('width', this.#bar.width());
    }

    resume() {
        this.#start = Date.now();
        clearTimeout(this.timeoutId);
        this.timeoutId = setTimeout(this.#callback, this.#time);
        this.#bar.css({'transition': `${this.#time}ms`, 'width': '100%'});
    }
} 
