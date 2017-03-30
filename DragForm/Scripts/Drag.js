function drap(id) {
    return document.getElementById(id);
}

/** 
 * 创建可拖拽对象的工厂方法 
 */
function createDraggableObject() {
    return {
        obj: null, left: 0, top: 0,
        oldX: 0, oldY: 0, isMouseLeftButtonDown: false,
        init: function (obj) {
            this.obj = obj;
            var that = this;
            this.obj.onmousedown = function (args) {
                var evt = args || event;
                this.style.zIndex = 100;
                that.isMouseLeftButtonDown = true;
                that.oldX = evt.clientX;
                that.oldY = evt.clientY;
                if (this.currentStyle) {
                    that.left = parseInt(this.currentStyle.left);
                    that.top = parseInt(this.currentStyle.top);
                }
                else {
                    var divStyle = document.defaultView.getComputedStyle(this, null);
                    that.left = parseInt(divStyle.left);
                    that.top = parseInt(divStyle.top);
                }
            };
            this.obj.onmousemove = function (args) {
                that.move(args || event);
            };
            this.obj.onmouseup = function () {
                that.isMouseLeftButtonDown = false;
                this.style.zIndex = 0;
            };
        },
        move: function (evt) {
            if (this.isMouseLeftButtonDown) {
                var dx = parseInt(evt.clientX - this.oldX);
                var dy = parseInt(evt.clientY - this.oldY);
                this.obj.style.left = (this.left + dx) + 'px';
                this.obj.style.top = (this.top + dy) + 'px';
            }
        }
    };
}