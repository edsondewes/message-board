import React, { useReducer } from "react";
import { post as postMessage } from "../../apis/messageApi";
import style from "./_style.css";

const TextLengthLimit = 250;

const initialState = {
  canSubmit: false,
  expanded: false,
  text: "",
};

function reducer(state, action) {
  switch (action.type) {
    case "write":
      return { ...state, canSubmit: action.text.length > 0, text: action.text };
    case "expand":
      return { ...state, expanded: true };
    case "retract":
      return { ...state, expanded: false };
    case "reset":
      return { canSubmit: false, expanded: false, text: "" };
    default:
      throw new Error();
  }
}

function MessageForm() {
  const [state, dispatch] = useReducer(reducer, initialState);

  function onBlur() {
    if (state.text.length === 0) {
      dispatch({ type: "retract" });
    }
  }

  function onChange(event) {
    const currentLength = event.target.value.length;
    if (currentLength <= TextLengthLimit) {
      dispatch({ type: "write", text: event.target.value });
    }
  }

  function onFocus() {
    dispatch({ type: "expand" });
  }

  async function onSubmit(event) {
    event.preventDefault();
    await postMessage({
      text: state.text,
    });

    dispatch({ type: "reset" });
  }

  return (
    <form
      onSubmit={onSubmit}
      className={`${style.messageForm} ${state.expanded ? style.expanded : ""}`}
    >
      <textarea
        aria-label="Write what's in your mind"
        onBlur={onBlur}
        onChange={onChange}
        onFocus={onFocus}
        value={state.text}
        placeholder="What's in your mind?"
        rows="1"
      />
      <div className={style.options}>
        <span>
          {state.text.length}/{TextLengthLimit}
        </span>
        <input
          {...(!state.canSubmit ? { disabled: true } : {})}
          className={style.btnSubmit}
          type="submit"
          value="Submit"
        />
      </div>
    </form>
  );
}

export default React.memo(MessageForm);
