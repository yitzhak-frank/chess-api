/* eslint-disable */

export const renderHTML = () => {
    const { state: { table: matrix } } = history;
    const table = $('.table-container table');
    const trMarks = $(`<tr class="row marks"><td class="mark"></td></tr>`);
    
    matrix.forEach((row, x) => {
        const tr = $(`<tr class="row"></tr>`);
        const tdMarkABC = $(`<td class="mark">${row[x][0]}</td>`);
        const tdMark123 = $(`<td class="mark">${x +1}</td>`);

        row.forEach((cell, y) => {
            const td = $(`<td class="col"><div id="${matrix[y][x]}" class="bg"></div></td>`);
            tr.append(td);
        });

        table.append(tr);
        tr.prepend(tdMark123);
        $(tdMark123).clone().appendTo(tr);
        $(tdMarkABC).clone().appendTo(trMarks);
    });
    trMarks.append('<td class="mark"></td>');
    table.prepend(trMarks);
    $(trMarks).clone().appendTo(table);
}

export const insertTools = () => {
    const { state: { table, tools } } = history;
    table.forEach((row) => row.forEach((col) => tools[col] && $(`td .bg#${col}`).html(`<div class="tool">${tools[col].tool}</div>`)));
}

export const removeAllTools = () => $('.tool').remove();
