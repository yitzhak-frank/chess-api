/* eslint-disable */

export const dragAndDrop = (event, element) => {

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
        $(element).css({'position': '', 'top': '', 'left': ''});
        document.onmouseup = null;
        document.onmousemove = null;
        dropElement(e);
    }

    const dropElement = ({ x, y }) => {
      const target = document.elementFromPoint(x, y);
      if(element === target) return;
      const click = function() { this.click(); };
      $(target).on('drop', click).trigger('drop').off('drop', click);
    }

    startDragElement(event);
}