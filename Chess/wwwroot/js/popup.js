/* eslint-disable */

export class PopupTimer {
    
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

export const popupMessageHandler = () => {

    const { state: { messages, Timer }} = history;

    clearTimeout(Timer.timeoutId);
    closePopup();

    if(!messages.length || messages.every(msg => !msg)) return;
    
    $('.toast .message').html('<ul></ul>');
    messages.forEach(msg => $('.toast .message ul').append(`<li>${msg}</li>`));
    $('.toast').fadeIn(500);

    history.state.Timer = new PopupTimer(5000, closePopup);
    history.state.Timer.resume();
}

export const closePopup = () => $('.toast').fadeOut(500).children('.toast .progress-bar').css({'transition': 'none', 'width': '0'});
